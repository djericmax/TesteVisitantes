using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVisitantes.Models
{
    public class Departamento
    {
        public Departamento() { }
        public Departamento(int id, string depto)
        {
            this.Id = id;
            this.Depto = depto;
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Departamento")]
        [MaxLength(50, ErrorMessage = "Campo pode ter no máximo 50 caracteres")]
        public string Depto { get; set; }
    }
}
