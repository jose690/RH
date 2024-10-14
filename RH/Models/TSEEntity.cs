using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RH.Models
{
    public class TSEEntity
    {
        [Key] // This is for the primary key
        [Column(TypeName = "char(10)")]
        public string Cedula { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        public string FechaNacimiento { get; set; }

        [Required]
        [Column(TypeName = "char(1)")]
        public string Genero { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Apellido1 { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Apellido2 { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Nombre { get; set; }

        [Column(TypeName = "char(10)")]
        public string Padre { get; set; }

        [Column(TypeName = "char(10)")]
        public string Madre { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string FechaRevision { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string FechaDefuncion { get; set; }

        [Column(TypeName = "varchar(95)")]
        public string NombreCompletoMadre { get; set; }

        [Column(TypeName = "varchar(95)")]
        public string NombreCompletoPadre { get; set; }
    }
}
