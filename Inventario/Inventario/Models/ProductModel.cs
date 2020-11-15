using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {

    [Table("productos")]
    public class ProductModel {
        [Column("codigo")] 
        public string code { get; set; }
        
        [Column("descripcion")] 
        public string description { get; set; }
        
        [Column("fecha")] 
        public DateTime date { get; set; }
        
        [Column("foto")] 
        public byte[] photo { get; set; }

        public int id { get; set; }
        
        [Column("id_categoria")] 
        public int category { get; set; }
        
        [Column("id_usuario")] 
        public int user { get; set; }
        
        [Column("precio_compra")] 
        public int purchasePrice { get; set; }
        
        [Column("precio_venta")] 
        public int salePrice { get; set; }
    }
}
