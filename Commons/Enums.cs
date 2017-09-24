using System;
using System.ComponentModel;

namespace Commons
{
    public class Enums
    {
        public enum UploadFolder
        {
            [Description("shop-khh/category/")]
            Category,

            [Description("shop-khh/product/")]
            Product
        }

        public enum UnitType
        {
            [Description("Tấm")]
            Tam = 17,
            [Description("Mét")]
            Met = 26,
            [Description("Ký")]
            Kg = 27,
            [Description("Cái")]
            Cai = 18,
            [Description("Bao")]
            Bao = 31,
            [Description("Cuộn")]
            Cuon = 23,
            [Description("Cây")]
            Cay = 25,
            [Description("Bành")]
            Banh = 30,
            [Description("Miếng")]
            Mieng = 19,
            [Description("Kiện")]
            Kien = 20,
            [Description("Cục")]
            Cuc = 21,
            [Description("Bó")]
            Bos = 22,
            [Description("Sợi")]
            Soi = 24,
            [Description("Cặp")]
            Cap = 28,
            [Description("Bộ")]
            Boj = 29,
        }
    }
}
