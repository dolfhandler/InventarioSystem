using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {

    [Table("tercerosxtelefono")]
    public class TerceroPorTelefonoModel {
        
        public int id { get; set; }
        
        [Column("id_cliente")] 
        public int client { get; set; }
        
        [Column("numero")] 
        public int tel { get; set; }
        
        [Column("tipo")] 
        public string type { get; set; }
    }
}
