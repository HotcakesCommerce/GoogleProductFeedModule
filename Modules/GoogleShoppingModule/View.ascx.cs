/*
' Copyright (c) 2016 Hotcakes Commerce, LLC
'  All rights reserved.
' 
' Permission is hereby granted, free of charge, to any person obtaining a copy 
' of this software and associated documentation files (the "Software"), to deal 
' in the Software without restriction, including without limitation the rights 
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
' copies of the Software, and to permit persons to whom the Software is 
' furnished to do so, subject to the following conditions:
' 
' The above copyright notice and this permission notice shall be included in all 
' copies or substantial portions of the Software.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
' SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BarcodeLib;
using DotNetNuke.Services.Exceptions;
using Hotcakes.Commerce;
using Hotcakes.Commerce.Catalog;
using Hotcakes.Commerce.Storage;
using Hotcakes.Commerce.Utilities;
using Hotcakes.Modules.GoogleShoppingModule.Components;
using Hotcakes.Modules.GoogleShoppingModule.Entities;
using Hotcakes.Web.Barcodes;

namespace Hotcakes.Modules.GoogleShoppingModule
{
    public partial class View : GoogleShoppingModuleBase
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack) BindData();
            }
            catch (Exception exc) 
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void btnBuildGoogleFeed_OnClick(object sender, EventArgs e)
        {
            BuildGoogleFeed();
        }

        #endregion

        #region Helper Methods

        private void BindData()
        {
            LocalizeModule();
        }

        private void LocalizeModule()
        {
            btnBuildGoogleFeed.Text = GetLocalizedString("btnBuildGoogleFeed");
        }

        private void BuildGoogleFeed()
        {
            //
            // the majority of the code to follow is based upon the excellent blog below:
            // http://blog.codenamed.nl/2015/05/14/creating-a-google-shopping-feed-with-c/
            //

            // get an instance of the store application
            var HccApp = HotcakesApplication.Current;

            var totalProducts = 0;
            var feed = new FeedInfo();

            // get the store URL based upon SSL
            var storeUrl = Request.IsSecureConnection ? HccApp.CurrentStore.RootUrlSecure() : HccApp.CurrentStore.RootUrl();
            // used to get currency code
            var regionInfo = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);

            feed.Link = storeUrl;
            feed.Title = HccApp.CurrentStore.StoreName;
            feed.Updated = DateTime.Now;
            feed.Entries = new List<EntryInfo>();

            // find all products in the store that are active
            var searchCriteria = new ProductSearchCriteria
            {
                DisplayInactiveProducts = false
            };

            // using the search instead of querying the Products directly to use cache
            var products = HccApp.CatalogServices.Products.FindByCriteria(searchCriteria, 1, int.MaxValue, ref totalProducts);

            // non-shipping
            var shippingInfo = new ShippingInfo { Price = Constants.HARDCODED_PRICE_ZERO };
            // not taxable (e.g., software)
            var taxInfo = new TaxInfo { Rate = Constants.HARDCODED_PRICE_ZERO };

            // iterate through each product and add it to the feed
            foreach (var product in products)
            {
                var productUrl = UrlRewriter.BuildUrlForProduct(product);

                var productEntry = new EntryInfo
                {
                    Availablity = GetStockMessage(product), // OPTIONS: preorder, in stock, out of stock 
                    Condition = Constants.CONDITION_NEW, // OPTIONS: new, refurbished, used
                    Description = product.LongDescription,
                    GoogleProductCategory = Constants.HARDCODED_GOOGLE_CATEGORY, // hard-coded for this example project (see property attributes)
                    Id = product.Sku,
                    ImageLink = DiskStorage.ProductImageUrlMedium(HccApp, product.Bvin, product.ImageFileMedium, Request.IsSecureConnection),
                    Link = productUrl,
                    MobileLink = productUrl,
                    Price = string.Format(Constants.CURRENCY_TEXT_FORMAT, product.SitePrice.ToString(Constants.CURRENCY_FORMAT), regionInfo.ISOCurrencySymbol),
                    ProductType = GetFirstAvailableCategory(HccApp, product.Bvin), // put your preferred site category here
                    Title = product.ProductName,
                    MPN = product.Sku, // this should be replaced with real data
                    Brand = product.VendorId, // this should be replaced with real data
                    Color = string.Empty,
                    Gender = Constants.GENDER_UNISEX, // OPTIONS: male, female, unisex
                    AgeGroup = Constants.AGE_GROUP_ADULT, // OPTIONS: newborn, infant, toddler, kids, adult
                    GTIN = GenerateGTIN() // this should be replaced with real data
                };

                // this could and should be iterated on to show shipping options for up to 100 locations
                productEntry.Shipping = new List<ShippingInfo>();
                productEntry.Shipping.Add(shippingInfo);

                // this could and should be iterated on to show taxes for up to 100 locations
                productEntry.Tax = new List<TaxInfo>();
                productEntry.Tax.Add(taxInfo);

                feed.Entries.Add(productEntry);
            }

            // simply done to display the feed in the textbox
            // alternatives could be to send this through a web service or other means
            txtGoogleFeed.Text = feed.SerializeObject();
        }

        private string GetStockMessage(Product product)
        {
            // OPTIONS: preorder, in stock, out of stock 

            if (!product.IsAvailableForSale)
            {
                return Constants.STOCK_OUT;
            }

            switch (product.InventoryMode)
            {
                case ProductInventoryMode.AlwayInStock:
                case ProductInventoryMode.NotSet:
                    return Constants.STOCK_IN;
                case ProductInventoryMode.WhenOutOfStockAllowBackorders:
                    return Constants.STOCK_PREORDER;
                default:
                    return Constants.STOCK_IN;
            }
        }

        private string GetFirstAvailableCategory(HotcakesApplication HccApp, string productBvin)
        {
            // you should have more complex and thought-out logic here
            try
            {
                var categories = HccApp.CatalogServices.FindCategoriesForProduct(productBvin);

                var category = categories.FirstOrDefault();

                return category.Name;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private string GenerateGTIN()
        {
            //
            // You should generate a GTIN that's more specific to your store, NOT this.
            //
            // See the documentation below to see what and how to properly use this value:
            // https://support.google.com/merchants/answer/188494?hl=en
            //

            return "3234567890126"; // example fromm Google
        }

        #endregion
    }
}