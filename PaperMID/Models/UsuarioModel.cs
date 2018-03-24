using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string ContraseñaUsu { get; set; }
        public string NombreUsu { get; set; }
        public string ApellidoPaternoUsu { get; set; }
        public string ApellidoMaternoUsu { get; set; }
        public string RFCUsu { get; set; }
        public string RazonSocioUsu { get; set; }
        public string TelefonoUsu { get; set; }
        public string CorreoUsu { get; set; }
        public int IdTipoUsuario1 { get; set; }
        public int IdDireccion2 { get; set; }
    }
}