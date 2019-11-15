using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TShirtAppAPI.Models
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

        [System.ComponentModel.DataAnnotations.Key]
        public int OrderId { get; set; }
    }
}

