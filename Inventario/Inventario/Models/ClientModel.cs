using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {

    [Table("clientes")]
    public class ClientModel {
        
        [Column("fecha")] 
        public DateTime date { get; set; }
         
        public int id { get; set; }
        
        [Column("id_tercero")] 
        public int tercero { get; set; }
        
        [Column("id_usuario")] 
        public int user { get; set; }
    }
}
