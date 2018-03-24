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
    public class TipoProductoController : Controller
    {
        ServicioAPI oServicioAPI;

        // CRUD TipoProducto
        [HttpGet]
        public async Task<ActionResult> ListeDépartement()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/TipoProducto");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oProveedorModel = JsonConvert.DeserializeObject<List<TipoProductoModel>>(Datos);
                return Json(new { data = oProveedorModel }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> TrouverDépartement(int IdTipoProducto)
        {
            if (IdTipoProducto > 0)
            {
                string Query = string.Format("/api/TipoProducto/" + IdTipoProducto);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync(Query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                    var Proveedor = JsonConvert.DeserializeObject<TipoProductoModel>(Datos);
                    return Json(Proveedor);
                }
                else { return Json(null); }
            }
            else
                return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> EnvogerDépartement(TipoProductoModel oTipoProductoModel)
        {
            if (oTipoProductoModel.IdTipoProducto > 0)//Éditer
            {
                string Query = string.Format("/api/TipoProducto/" + oTipoProductoModel.IdTipoProducto);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PutAsJsonAsync(Query, oTipoProductoModel);
            }
            else//Enrregistrer
            {
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/TipoProducto", oTipoProductoModel);
            }
            return Json(oTipoProductoModel);
        }

        [HttpPost]
        public async Task<ActionResult> ÉliminerDépartement(int IdTipoProducto)
        {
            bool Success = false;
            if (IdTipoProducto > 0)
            {
                string Query = string.Format("/api/TipoProducto/" + IdTipoProducto);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.DeleteAsync(Query);
                Success = (responseMessage.IsSuccessStatusCode) ? true : false;
            }
            return new JsonResult { Data = new { success = Success } };
        }
    }
}