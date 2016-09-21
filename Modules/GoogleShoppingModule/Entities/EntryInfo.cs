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
using System.Xml.Serialization;

namespace Hotcakes.Modules.GoogleShoppingModule.Entities
{
    /// <summary>
    /// Used to represent each individual product to Google
    /// </summary>
    /// <remarks>
    /// This is just a way for you to get started. There are many missing attributes that you might want to consider adding.
    /// </remarks>
    [XmlType(TypeName = "entry"), Serializable]
    public class EntryInfo
    {
        /// <summary>
        /// A uniuqe identifier for the product, such as the SKU.
        /// </summary>
        [XmlElement("id", Namespace = "http://base.google.com/ns/1.0")]
        public string Id { get; set; }

        /// <summary>
        /// Name or title of the product
        /// </summary>
        [XmlElement("title", Namespace = "http://base.google.com/ns/1.0")]
        public string Title { get; set; }

        /// <summary>
        /// Product description usually seen in the product details
        /// </summary>
        [XmlElement("description", Namespace = "http://base.google.com/ns/1.0")]
        public string Description { get; set; }

        /// <summary>
        /// Permanent URL to the product
        /// </summary>
        [XmlElement("link", Namespace = "http://base.google.com/ns/1.0")]
        public string Link { get; set; }

        /// <summary>
        /// If there is a mobile-specific URL, it should be specified
        /// </summary>
        [XmlElement("mobile_link", Namespace = "http://base.google.com/ns/1.0")]
        public string MobileLink { get; set; }

        /// <summary>
        /// The URL to the primary image of the product
        /// </summary>
        [XmlElement("image_link", Namespace = "http://base.google.com/ns/1.0")]
        public string ImageLink { get; set; }

        /// <summary>
        /// Condition of the product, including: new, refurbished, used
        /// </summary>
        [XmlElement("condition", Namespace = "http://base.google.com/ns/1.0")]
        public string Condition { get; set; }

        /// <summary>
        /// Availability of the product, including: preorder, in stock, out of stock 
        /// </summary>
        [XmlElement("availability", Namespace = "http://base.google.com/ns/1.0")]
        public string Availablity { get; set; }

        /// <summary>
        /// Price that this product is sold for on your site
        /// </summary>
        [XmlElement("price", Namespace = "http://base.google.com/ns/1.0")]
        public string Price { get; set; }

        /// <summary>
        /// If available, the sale price that the prod
        /// </summary>
        [XmlElement("sale_price", Namespace = "http://base.google.com/ns/1.0")]
        public string SalePrice { get; set; }

        [XmlElement("brand", Namespace = "http://base.google.com/ns/1.0")]
        public string Brand { get; set; }

        /// <summary>
        /// Manufacturer Part Number
        /// </summary>
        [XmlElement("mpn", Namespace = "http://base.google.com/ns/1.0")]
        public string MPN { get; set; }

        [XmlElement("gtin", Namespace = "http://base.google.com/ns/1.0")]
        public string GTIN { get; set; }

        [XmlElement("shipping", Namespace = "http://base.google.com/ns/1.0")]
        public List<ShippingInfo> Shipping { get; set; }

        /// <summary>
        /// The string value matching a category in Google's taxonomy
        /// </summary>
        /// <remarks>
        /// Google's Taxonomy: https://support.google.com/merchants/answer/1705911
        /// </remarks>
        [XmlElement("google_product_category", Namespace = "http://base.google.com/ns/1.0")]
        public string GoogleProductCategory { get; set; }

        /// <summary>
        /// The primary category for the product in your store
        /// </summary>
        [XmlElement("product_type", Namespace = "http://base.google.com/ns/1.0")]
        public string ProductType { get; set; }

        /// <summary>
        /// The primary color for the product
        /// </summary>
        [XmlElement("color", Namespace = "http://base.google.com/ns/1.0")]
        public string Color { get; set; }

        /// <summary>
        /// Which sex the product is intended for
        /// </summary>
        /// <remarks>
        /// OPTIONS: male, female, unisex
        /// </remarks>
        [XmlElement("gender", Namespace = "http://base.google.com/ns/1.0")]
        public string Gender { get; set; }

        /// <summary>
        /// The intended age group for the product
        /// </summary>
        /// <remarks>
        /// OPTIONS: newborn, infant, toddler, kids, adult
        /// </remarks>
        [XmlElement("age_group", Namespace = "http://base.google.com/ns/1.0")]
        public string AgeGroup { get; set; }

        /// <summary>
        /// Tax rates for the product
        /// </summary>
        [XmlElement("tax", Namespace = "http://base.google.com/ns/1.0")]
        public List<TaxInfo> Tax { get; set; }
    }
}