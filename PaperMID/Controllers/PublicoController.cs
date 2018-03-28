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
    public class PublicoController : Controller
    {
        ServicioAPI oServicioAPI;
        // GET: Publico
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login( string user,string pass)
        {
            Login_ComprobacionModel _oLogin_ComprobacionModel = new Login_ComprobacionModel();
            _oLogin_ComprobacionModel.Usuario = user;
            _oLogin_ComprobacionModel.ContraseñaUsu = pass;
            oServicioAPI = new ServicioAPI();
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Login", _oLogin_ComprobacionModel);
            if (responseMessage.IsSuccessStatusCode)
            {
                string RespuestaLogin = responseMessage.Content.ReadAsStringAsync().Result;
                Login_RespuestaModel _oLogin_RespuestaModel = JsonConvert.DeserializeObject<Login_RespuestaModel>(RespuestaLogin);
                Session["IdUsuario"] = _oLogin_RespuestaModel.IdUsuario;
                return RedirectToAction("Inicio", _oLogin_RespuestaModel.Modulo);
            }
            else
            {
                return RedirectToAction("Inicio", "Publico");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Inicio", "Publico");
        }
    }
}