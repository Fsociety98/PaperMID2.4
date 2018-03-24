using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperMID.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        public string CódigoProd { get; set; }
        public string NombreProd { get; set; }
        public string DescripcionProd { get; set; }
        public double PrecioProd { get; set; }
        public double DescuentoProd { get; set; }
        public int CantidadDisponibleProd { get; set; }
        public int CantidadMinimaProd { get; set; }
        public int IdTipoProducto1 { get; set; }
        public int IdProveedor1 { get; set; }
    }
}