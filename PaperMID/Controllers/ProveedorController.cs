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
    public class ProveedorController : Controller
    {
        ServicioAPI oServicioAPI;
 
        // CRUD Fournisseur
        [HttpGet]
        public async Task<ActionResult> ListaProveedor()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Proveedor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oProveedorModel = JsonConvert.DeserializeObject<List<ProveedorModel>>(Datos);
                return Json(new { data = oProveedorModel }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerProveedor(int IdProveedor)
        {
            oServicioAPI = new ServicioAPI();
            if (IdProveedor > 0)
            {
                string Query = string.Format("/api/Proveedor/" + IdProveedor);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync(Query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                    var oProveedorModel = JsonConvert.DeserializeObject<ProveedorModel>(Datos);
                    return Json(oProveedorModel);
                }
                else { return Json(null); }
            }
            else
                return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> EnviarDatos(ProveedorModel oProveedorModel)
        {
            oServicioAPI = new ServicioAPI();
            if (oProveedorModel.IdProveedor > 0)//Éditer
            {
                string Query = string.Format("/api/Proveedor/" + oProveedorModel.IdProveedor);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PutAsJsonAsync(Query, oProveedorModel);
            }
            else//Enrregistrer
            {
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Proveedor", oProveedorModel);
            }
            return Json(oProveedorModel);
        }

        [HttpPost]
        public async Task<ActionResult> EliminarProveedor(int IdProveedor)
        {
            oServicioAPI = new ServicioAPI();
            bool Success = false;
            if (IdProveedor > 0)
            {
                string Query = string.Format("/api/Proveedor/" + IdProveedor);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.DeleteAsync(Query);
                Success = (responseMessage.IsSuccessStatusCode) ? true : false;
            }
            return new JsonResult { Data = new { success = Success } };
        }
    }
}