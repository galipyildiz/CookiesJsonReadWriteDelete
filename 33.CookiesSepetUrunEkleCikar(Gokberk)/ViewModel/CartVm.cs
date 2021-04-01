using _33.CookiesSepetUrunEkleCikar_Gokberk_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _33.CookiesSepetUrunEkleCikar_Gokberk_.ViewModel
{
    public class CartVm
    {
        public CartVm()
        {
            this.CreatedDate = DateTime.Now;
            this.Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
        public string Promocode { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Count { get; set; }
    }
}