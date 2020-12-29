using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {
    [Table("proveedores")]
    public class ProviderModel {

        [Column("fecha")]
        public DateTime date {
            get; set;
        }
       
        public int id {
            get; set;
        }

        [Column("id_tercero")]
        public int id_tercero {
            get; set;
        }

        [Column("id_usuario")]
        public int user {
            get; set;
        }

        [Column("pagina_web")]
        public string web_page {
            get; set;
        }

    }
}
