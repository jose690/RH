using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RH.Models
{
    public class TSEEntity
    {
        [Key] // This is for the primary key
        [Column(TypeName = "char(10)")]
        public required string Cedula { get; set; }

        [Required]
        [Column(TypeName = "varchar(12)")]
        public required string FechaNacimiento { get; set; }

        [Required]
        [Column(TypeName = "char(1)")]
        public required string Genero { get; set; }

        [Column(TypeName = "varchar(25)")]
        public required string Apellido1 { get; set; }

        [Column(TypeName = "varchar(25)")]
        public required string Apellido2 { get; set; }

        [Required]
        [Column(TypeName = "varchar(40)")]
        public required string Nombre { get; set; }

        [Column(TypeName = "char(10)")]
        public required string Padre { get; set; }

        [Column(TypeName = "char(10)")]
        public required string Madre { get; set; }

        [Column(TypeName = "varchar(10)")]
        public required string FechaRevision { get; set; }

        [Column(TypeName = "varchar(10)")]
        public required string FechaDefuncion { get; set; }

        [Column(TypeName = "varchar(95)")]
        public required string NombreCompletoMadre { get; set; }

        [Column(TypeName = "varchar(95)")]
        public required string NombreCompletoPadre { get; set; }
    }
}
