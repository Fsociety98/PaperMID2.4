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
    public class PromotionController : Controller
    {
        ServicioAPI oServicioAPI;

        // CRUD Promotion
        [HttpGet]
        public async Task<ActionResult> ListePromotion()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Promocion");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oPromocionModel = JsonConvert.DeserializeObject<List<PromocionModel>>(Datos);
                return Json(new { data = oPromocionModel }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> TrouverPromotion(int IdPromocion)
        {
            oServicioAPI = new ServicioAPI();
            if (IdPromocion > 0)
            {
                string Query = string.Format("/api/Promocion/" + IdPromocion);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync(Query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                    var oPromocionModel = JsonConvert.DeserializeObject<PromocionModel>(Datos);
                    return Json(oPromocionModel);
                }
                else { return Json(null); }
            }
            else
                return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> EnvogerPromotion(PromocionModel oPromocionModel)
        {
            oServicioAPI = new ServicioAPI();
            if (oPromocionModel.IdPromocion > 0)//Éditer
            {
                string Query = string.Format("/api/Promocion/" + oPromocionModel.IdPromocion);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PutAsJsonAsync(Query, oPromocionModel);
            }
            else//Enrregistrer
            {
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Promocion", oPromocionModel);
            }
            return Json(oPromocionModel);
        }

        [HttpPost]
        public async Task<ActionResult> ÉliminerPromotion(int IdPromocion)
        {
            oServicioAPI = new ServicioAPI();
            bool Success = false;
            if (IdPromocion > 0)
            {
                string Query = string.Format("/api/Promocion/" + IdPromocion);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.DeleteAsync(Query);
                Success = (responseMessage.IsSuccessStatusCode) ? true : false;
            }
            return new JsonResult { Data = new { success = Success } };
        }
    }
}