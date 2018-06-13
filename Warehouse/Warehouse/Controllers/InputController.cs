using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Warehouse.Models;



namespace Warehouse.Controllers
{
    public class InputController : Controller
    {

        // GET: Detail_Bill
        HomeModel db = new HomeModel();
        public ActionResult Index()
        {
            if (!ClassMore.Login_hasLogin)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Input> lsPro = db.Inputs.ToList();

            return View(lsPro);
        }

        [HttpPost]
        public ActionResult Add(String quantity, String supply, String product, String idInp)
        {
            try
            {
                Input pro;
                if ("".Equals(idInp))
                {
                    DateTime today = DateTime.Now;
                    pro = new Input();
                    pro.quantity = Int32.Parse(quantity);
                    pro.idSupply = Int32.Parse(supply);
                    pro.idProduct = Int32.Parse(product);
                    pro.date = today;
                    db.Inputs.Add(pro);
                    db.SaveChanges();

                }
                else
                {
                    int idProT = Int32.Parse(idInp.Trim());
                    pro = db.Inputs.FirstOrDefault(a => a.id == idProT);
                    if (pro != null)
                    {
                        pro.quantity = Int32.Parse(quantity);
                        pro.idSupply = Int32.Parse(supply);
                        pro.idProduct = Int32.Parse(product);
                        db.SaveChanges();
                    }

                }
            } catch(Exception)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }

            

            return RedirectToAction("Index", "Input");
        }

        public ActionResult Delete(String idInp)
        {
            
            try
            {
                int idProT = Int32.Parse(idInp.Trim());
                Input pro = db.Inputs.FirstOrDefault(a => a.id == idProT);
                if (pro != null)
                {
                    db.Inputs.Attach(pro);
                    db.Inputs.Remove(pro);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                ClassMore.Login_hasLogin = false;
                return RedirectToAction("Login", "Home");
            }
            

            return RedirectToAction("Index", "Input");
        }

        public String Initial_Product()
        {
            List<Product> lsPro = db.Products.ToList();
            String st = "[";
            int k = 0;
            foreach(Product pro in lsPro)
            {
                k++;
                st += "{\"id\":"+pro.id+",\"name\":\""+pro.name+"\"}";
                if(k != lsPro.Count)
                {
                    st += ",";
                }
            }
            st += "]";
            return st;
        }
        
        public String Initial_Supply(String id)
        {
            List<Supply> lsPro = db.Supplies.ToList();
            String st = "[";
            int k = 0;
            foreach (Supply pro in lsPro)
            {
                k++;
                st += "{\"id\":" + pro.id + ",\"name\":\"" + pro.name + "\"}";
                if (k != lsPro.Count)
                {
                    st += ",";
                }
            }
            st += "]";
            return st;
        }
    }

}