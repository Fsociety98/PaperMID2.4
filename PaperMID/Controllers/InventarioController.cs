using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Productos()
        {
            return View();
        }
        public ActionResult Promociones()
        {
            return View();
        }
        public ActionResult Ingresos()
        {
            return View();
        }
        public ActionResult Egresos()
        {
            return View();
        }
    }
}