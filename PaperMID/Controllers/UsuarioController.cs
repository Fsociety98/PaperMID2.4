﻿using Newtonsoft.Json;
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
    public class UsuarioController : Controller
    {
        ServicioAPI oServicioAPI;
 
        // CRUD Usager
        [HttpGet]
        public async Task<ActionResult> ListaUsuarios()
        {
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync("/api/Usuario");
            if (responseMessage.IsSuccessStatusCode)
            {
                var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                var oUsuarioModel = JsonConvert.DeserializeObject<List<UsuarioModel>>(Datos);
                return Json(new { data = oUsuarioModel }, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public async Task<JsonResult> ObtenerUsuario(int IdUsuario)
        {
            oServicioAPI = new ServicioAPI();
            if (IdUsuario > 0)
            {
                string Query = string.Format("/api/Usuario/" + IdUsuario);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.GetAsync(Query);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var Datos = responseMessage.Content.ReadAsStringAsync().Result;
                    var UsuarioModel = JsonConvert.DeserializeObject<UsuarioModel>(Datos);
                    return Json(UsuarioModel);
                }
                else { return Json(null); }
            }
            else
                return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> EnviarDatos(UsuarioModel oUsuarioModel)
        {
            oServicioAPI = new ServicioAPI();
            if (oUsuarioModel.IdUsuario > 0)//Éditer
            {
                string Query = string.Format("/api/Usuario/" + oUsuarioModel.IdUsuario);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PutAsJsonAsync(Query, oUsuarioModel);
            }
            else//Enrregistrer
            {
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Usuario", oUsuarioModel);
            }
            return Json(oUsuarioModel);
        }

        [HttpPost]
        public async Task<ActionResult> EliminarUsuario(int IdUsuario)
        {
            oServicioAPI = new ServicioAPI();
            bool Success = false;
            if (IdUsuario > 0)
            {
                string Query = string.Format("/api/Usuario/" + IdUsuario);
                HttpResponseMessage responseMessage = await oServicioAPI.Cliente.DeleteAsync(Query);
                Success = (responseMessage.IsSuccessStatusCode) ? true : false;
            }
            return new JsonResult { Data = new { success = Success } };
        }
    }
}