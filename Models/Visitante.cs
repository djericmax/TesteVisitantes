using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVisitantes.Models
{
    public class Visitante
    {
        public Visitante() { }
        public Visitante(int id, string empresa, DateTime horaChegada, DateTime horaSaida, DateTime data, string nome, int departamentoId)
        {
            this.Id = id;
            this.Empresa = empresa;
            this.HoraChegada = horaChegada;
            this.HoraSaida = horaSaida;
            this.Data = data;
            this.Nome = nome;
            this.DepartamentoId = departamentoId;
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Empresa")]
        [MaxLength(50, ErrorMessage = "Campo pode ter no máximo 50 caracteres")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name ="Horário de chegada")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraChegada { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Horário de Saída")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HoraSaida { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data da visita")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "Campo pode ter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Departamento")]
        [Range(1, int.MaxValue, ErrorMessage = "Departamento inválido")]
        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }
    }
}
