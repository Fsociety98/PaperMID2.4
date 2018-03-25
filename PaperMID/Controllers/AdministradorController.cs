using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class AdministradorController : Controller
    {

        // GET: Administrador
        public ActionResult Inicio()
        {
            return View();
        }
        public ActionResult Departamentos()
        {
            return View();
        }
    
        public ActionResult Proveedores()
        {
            return View();
        }
        public ActionResult Empleados()
        {
            return View();
        }
        public ActionResult DatosEmpresa()
        {
            return View();
        }

    }
}