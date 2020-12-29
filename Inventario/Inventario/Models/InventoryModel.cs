using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {

    [Table("inventario")]
    public class InventoryModel {
        [Column("entradas")]
        public int inputs { get; set; }

        [Column("salidas")]
        public int outputs { get; set; }

        [Column("existencia")]
        public int stock { get; set; }

        [Column("fecha")]
        public DateTime date { get; set; }

        public int id { get; set; }

        [Column("id_producto")]
        public int product { get; set; }
        
        [NotMapped]
        public string productName { get; set; }

        [Column("id_usuario")]
        public int user { get; set; }
    }
}
