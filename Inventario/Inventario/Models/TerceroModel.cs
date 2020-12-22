using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models {

    [Table("terceros")]
    public class TerceroModel {
        
        [Column("correo")]
        public string email { get; set; }
        
        [Column("direccion")] 
        public string addres { get; set; }
        
        [Column("fecha")] 
        public DateTime date { get; set; }
         
        public int id { get; set; }
        
        [Column("id_usuario")] 
        public int user { get; set; }
        
        [Column("numero")] 
        public string number { get; set; }
        
        [Column("primer_apellido")] 
        public string lastname { get; set; }
        
        [Column("primer_nombre")] 
        public string firstName { get; set; }
        
        [Column("segundo_apellido")] 
        public string secondLastname { get; set; }
        
        [Column("segundo_nombre")] 
        public string middleName { get; set; }
        
        [Column("tpo_documento")] 
        public string documentType { get; set; }

        [NotMapped]
        public string fullName { get; set; }
    }
}
