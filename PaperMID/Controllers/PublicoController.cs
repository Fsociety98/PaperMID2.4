using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaperMID.Models;
using PaperMID.WebService;


namespace PaperMID.Controllers
{
    public class PublicoController : Controller
    {
        // GET: Publico
        public ActionResult Inicio()
        {
            return View();
        }
    }
}