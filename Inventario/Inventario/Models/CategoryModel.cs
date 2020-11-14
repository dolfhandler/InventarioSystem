using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {

    [Table("categorias")]
    public class CategoryModel {
        [Key]
        public int id { get; set; }

        [Column("descripcion")]
        public string description { get; set; }

        [Column("fecha")]
        public DateTime date { get; set; }

        [Column("id_usuario")]
        public int idUser { get; set; }
    }
}
