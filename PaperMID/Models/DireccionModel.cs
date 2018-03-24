using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class DireccionModel
    {
        public int IdDireccion { get; set; }
        public string CalleDir { get; set; }
        public string NumInteDir { get; set; }
        public string NumExteDir { get; set; }
        public string CruzaDir { get; set; }
        public string ColoniaDir { get; set; }
        public string CPDir { get; set; }
        public string UbicacionDir { get; set; }
        public string LatitudDir { get; set; }
        public string LongitudDir { get; set; }
        public int IdMunicipio1 { get; set; }
    }
}