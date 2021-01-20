using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {
    [Table("compraxproductos")]
    public class PurshasesProductsModel {
        [Column("cantidad")]
        public int quantity {
            get; set;
        }
        [Column("fecha")]
        public DateTime date {
            get; set;
        }
        [Column("id")]
        public int id {
            get; set;
        }
        [Column("id_compra")]
        public int id_compra {
            get; set;
        }
        [Column("id_producto")]
        public int id_producto {
            get; set;
        }
        [Column("id_usuario")]
        public int user {
            get; set;
        }
        [Column("precio")]
        public int price {
            get; set;
        }
    }
}
