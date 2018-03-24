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
    public class ProduitController : Controller
    {
        ServicioAPI oServicioAPI;

        // Liste Département - Dropdowlist
        [HttpGet]
        public async Task<ActionResult> ListeDépartement()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/TipoProducto");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oTipoProductoModel = JsonConvert.DeserializeObject<List<TipoProductoModel>>(Datos);
                return Json(oTipoProductoModel, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        //Liste Fournisseur - Dropdowlist
        [HttpGet]
        public async Task<ActionResult> ListeFournisseur()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Proveedor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oProveedorModel = JsonConvert.DeserializeObject<List<ProveedorModel>>(Datos);
                return Json(oProveedorModel, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }
        // CRUD Produit
        [HttpGet]
        public async Task<ActionResult> ListeProduit()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Producto");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oProductoModel = JsonConvert.DeserializeObject<List<ProductoModel>>(Datos);
                return Json(new { data = oProductoModel }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> TrouverProduit(int IdProducto)
        {
            oServicioAPI = new ServicioAPI();
            if (IdProducto > 0)
            {
                string Query = string.Format("/api/Producto/" + IdProducto);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync(Query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                    var oProductoModel = JsonConvert.DeserializeObject<ProductoModel>(Datos);
                    return Json(oProductoModel);
                }
                else { return Json(null); }
            }
            else
                return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> EnvogerProduit(ProductoModel oProductoModel)
        {
            oServicioAPI = new ServicioAPI();
            if (oProductoModel.IdProducto > 0)//Éditer
            {
                string Query = string.Format("/api/Producto/" + oProductoModel.IdProducto);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PutAsJsonAsync(Query, oProductoModel);
            }
            else//Enrregistrer
            {
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Producto", oProductoModel);
            }
            return Json(oProductoModel);
        }

        [HttpPost]
        public async Task<ActionResult> ÉliminerProduit(int IdProducto)
        {
            oServicioAPI = new ServicioAPI();
            bool Success = false;
            if (IdProducto > 0)
            {
                string Query = string.Format("/api/Producto/" + IdProducto);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.DeleteAsync(Query);
                Success = (responseMessage.IsSuccessStatusCode) ? true : false;
            }
            return new JsonResult { Data = new { success = Success } };
        }
    }
}