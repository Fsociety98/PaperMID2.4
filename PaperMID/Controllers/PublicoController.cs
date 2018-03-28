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
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace PaperMID.Controllers
{
    public class PublicoController : Controller
    {
        Account account = new Account("papermid", "653559145735427", "5WQiErWAQ8lRh_RS7DNm1ZkCorI");
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
        public async Task<ActionResult> Login(string Usuario, string ContraseñaUsu)
        {
            oServicioAPI = new ServicioAPI();
            Login_ComprobacionModel _oLogin_ComprobacionModel = new Login_ComprobacionModel();
            _oLogin_ComprobacionModel.Usuario = Usuario;
            _oLogin_ComprobacionModel.ContraseñaUsu = ContraseñaUsu;
            HttpResponseMessage responseMessage = await oServicioAPI.Cliente.PostAsJsonAsync("/api/Login", _oLogin_ComprobacionModel);
            if (responseMessage.IsSuccessStatusCode)
            {
                string RespuestaLogin = responseMessage.Content.ReadAsStringAsync().Result;
                Login_RespuestaModel _oLogin_RespuestaModel = JsonConvert.DeserializeObject<Login_RespuestaModel>(RespuestaLogin);
                Session["IdUsuario"] = _oLogin_RespuestaModel.IdUsuario;
                Session["NombreUsu"] = _oLogin_RespuestaModel.NombreUsu;
                string NombreUser = _oLogin_RespuestaModel.NombreUsu;
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

       

       
        public ActionResult Imagen()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult SubirImg(string url)
        {
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(url)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            Imagen();
            return View(@"Imagen");
        }






    }
}