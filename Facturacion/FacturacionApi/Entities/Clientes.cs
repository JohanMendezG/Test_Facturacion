using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionApi.Entities
{
    public class Cliente
    {
        [Key]
        [Required]
        public long Documento { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z\s]{1,}$", ErrorMessage = "Digite solo caracteres alfabeticos sin tildes")]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Maximo 20 caracteres permitidos")]
        [RegularExpression(@"^[a-zA-Z\s]{1,}$", ErrorMessage = "Digite solo caracteres alfabeticos sin tildes")]
        public string PrimerApellido { get; set; }
        [MaxLength(20, ErrorMessage = "Maximo 20 caracteres permitidos")]
        public string SegundoApellido { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{2,3}$", ErrorMessage = "Digite solo caracteres numericos")]
        public int Edad { get; set; }
    }
}