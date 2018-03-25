using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class EmpresaModel
    {
        public int IdPapeleria { get; set; }
        public string NombrePape { get; set; }
        public string MisionPape { get; set; }
        public string VisionPape { get; set; }
        public string ValoresPape { get; set; }
        public string CorreoPape { get; set; }
        public string TelefenoPape { get; set; }
        public int IdDireccion1 { get; set; }
    }
}