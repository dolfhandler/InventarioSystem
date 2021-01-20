using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {
    [Table("compras")]
    public class PurshaseModel {

        [Column("fecha")]
        public DateTime date {
            get; set;
        }
        [Column("id")]
        public int id {
            get; set;
        }
        [Column("id_comprobante")]
        public int id_comprobante {
            get; set;
        }
        [Column("id_proveedor")]
        public int id_proveedor {
            get; set;
        }
        [Column("id_usuario")]
        public int user {
            get; set;
        }
        [Column("numero_comprobante")]
        public string number_voucher {
            get; set;
        }
        [Column("total")]
        public int total {
            get; set;
        }
    }
}
