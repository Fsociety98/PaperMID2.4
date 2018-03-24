using Newtonsoft.Json;
using PaperMID.Models;
using PaperMID.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PaperMID.Controllers
{
    public class AdresseController : Controller
    {
        ServicioAPI oServicioAPI;
        // CRUD Adresse
        [HttpGet]
        public async Task<ActionResult> ListeAdresse()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Direccion");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Donnés = responseMessage.Content.ReadAsStringAsync().Result;
                var oDireccionModel = JsonConvert.DeserializeObject<List<DireccionModel>>(Donnés);
                return Json(new { data = oDireccionModel }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> TrouverAdresse(int IdDireccion)
        {
            oServicioAPI = new ServicioAPI();
            if (IdDireccion > 0)
            {
                string Query = string.Format("/api/Direccion/" + IdDireccion);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync(Query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Donnés = responseMessage.Content.ReadAsStringAsync().Result;
                    var oDireccionModel = JsonConvert.DeserializeObject<DireccionModel>(Donnés);
                    return Json(oDireccionModel);
                }
                else { return Json(null); }
            }
            else
                return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> EnvogerAdresse(DireccionModel oDireccionModel)
        {
            oServicioAPI = new ServicioAPI();
            if (oDireccionModel.IdDireccion > 0)//Éditer
            {
                string Query = string.Format("/api/Direccion/" + oDireccionModel.IdDireccion);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PutAsJsonAsync(Query, oDireccionModel);
            }
            else//Enrregistrer
            {
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Direccion", oDireccionModel);
            }
            return Json(oDireccionModel);
        }

        [HttpPost]
        public async Task<ActionResult> ÉliminerAdresse(int IdDireccion)
        {
            oServicioAPI = new ServicioAPI();
            bool Success = false;
            if (IdDireccion > 0)
            {
                string Query = string.Format("/api/Direccion/" + IdDireccion);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.DeleteAsync(Query);
                Success = (responseMessage.IsSuccessStatusCode) ? true : false;
            }
            return new JsonResult { Data = new { success = Success } };
        }
    }
}