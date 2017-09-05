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
            [Description("Mét")]
            Met,
            [Description("Ký")]
            Kg,
            [Description("Cái")]
            Cai,
            [Description("Bao")]
            Bao,
            [Description("Cuộn")]
            Cuon,
            [Description("Cây")]
            Cay,
            [Description("Bình")]
            Binh
        }
    }
}
