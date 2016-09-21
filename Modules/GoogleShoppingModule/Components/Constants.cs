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

using System.Security.Cryptography.X509Certificates;

namespace Hotcakes.Modules.GoogleShoppingModule.Components
{
    public static class Constants
    {
        public const string HARDCODED_PRICE_ZERO = "0.00";
        public const string HARDCODED_GOOGLE_CATEGORY = "2092";

        public const string CURRENCY_FORMAT = "#.##";
        public const string CURRENCY_TEXT_FORMAT = "{0} {1}";

        public const string CONDITION_NEW = "new";
        public const string CONDITION_REFURBISHED = "refurbished";
        public const string CONDITION_USED = "used";

        public const string GENDER_MALE = "male";
        public const string GENDER_FEMALE = "female";
        public const string GENDER_UNISEX = "unisex";

        public const string AGE_GROUP_NEWBORN = "newborn";
        public const string AGE_GROUP_INFANT = "infant";
        public const string AGE_GROUP_TODDLER = "toddler";
        public const string AGE_GROUP_KID = "kids";
        public const string AGE_GROUP_ADULT = "adult";

        public const string STOCK_OUT = "out of stock";
        public const string STOCK_IN = "in stock";
        public const string STOCK_PREORDER = "preorder";
    }
}