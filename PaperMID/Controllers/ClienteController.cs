using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PaperMID.Models;
using PaperMID.WebService;

namespace PaperMID.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        ServicioAPI oServicioAPI;
        public ActionResult Inicio()
        {
            return View();
        }
        // hace un Hilo asincrono
        public async Task<ActionResult> QuienesSomos()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Empresa");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var _oEmpresaModel = JsonConvert.DeserializeObject<List<EmpresaModel>>(Datos);
                return View(_oEmpresaModel);
            }
            else
            {
                return View();
            }

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Inicio", "Publico");
        }
    }
}