using _33.CookiesSepetUrunEkleCikar_Gokberk_.Models;
using _33.CookiesSepetUrunEkleCikar_Gokberk_.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _33.CookiesSepetUrunEkleCikar_Gokberk_.Controllers
{
    public class CookieController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public ActionResult SatinAl(int id)
        {
            CartVm vm = new CartVm();
            if (Request.Cookies.AllKeys.Contains("kart"))
            {
                vm = JsonConvert.DeserializeObject<CartVm>(Request.Cookies["kart"].Value);
            }
           
            Product product = db.Products.Find(id);
            vm.Products.Add(product);
            vm.Count = vm.Products.Count;
            if (vm.Promocode != null && vm.Promocode == "galip50")
            {
                vm.TotalPrice = vm.Products.Sum(x => x.Price) * 0.5m;
            }
            else
            {
                vm.TotalPrice = vm.Products.Sum(x => x.Price);
            }
            
            string json = JsonConvert.SerializeObject(vm);
            HttpCookie kart = new HttpCookie("kart", json);
            kart.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(kart);
            ViewBag.Sayi = vm.Products.Count;
            return Json(id);
        }
        public ActionResult Listele()
        {
            if (Request.Cookies.AllKeys.Contains("kart"))
            {
                CartVm vm = JsonConvert.DeserializeObject<CartVm>(Request.Cookies["kart"].Value);
                return Json(vm, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Indirim(string kod)
        {
            string promoCode = "galip50";
            CartVm vm = JsonConvert.DeserializeObject<CartVm>(Request.Cookies["kart"].Value);
            if (kod == promoCode && vm.Promocode == null && vm.Products.Count > 0)
            {
                vm.Promocode = kod;
                vm.TotalPrice = vm.TotalPrice - (vm.TotalPrice * 0.5m);
                string json = JsonConvert.SerializeObject(vm);
                HttpCookie kart = new HttpCookie("kart", json);
                kart.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(kart);
                return Json(vm);
            }
            else
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult Sil(int id)
        {
            CartVm vm = JsonConvert.DeserializeObject<CartVm>(Request.Cookies["kart"].Value);
            Product product = db.Products.Find(id);
            Product deletedProduct = vm.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            vm.Products.Remove(deletedProduct);
            vm.Count = vm.Products.Count;
            if (vm.Promocode != null && vm.Promocode == "galip50")
            {
                vm.TotalPrice = vm.Products.Sum(x => x.Price) * 0.5m;
            }
            else
            {
                vm.TotalPrice = vm.Products.Sum(x => x.Price);
            }
            //vm.TotalPrice -= product.Price;
            string json = JsonConvert.SerializeObject(vm);
            HttpCookie kart = new HttpCookie("kart", json);
            kart.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(kart);
            return Json(vm);
        }
    }
}