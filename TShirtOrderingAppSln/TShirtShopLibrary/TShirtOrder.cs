using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtShopLibrary
{
    public class TShirtOrder
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ImgSrc { get; set; }

        public bool Status { get; set; }

        public string ShippingAddress { get; set; }
        [PrimaryKey, AutoIncrement]
        public int OrderId { get; set; }
    }
}
