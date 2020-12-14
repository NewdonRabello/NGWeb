using System;
using System.ComponentModel.DataAnnotations;
namespace NGWebV1.Models
{
    public class Cliente : CamposAuditoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public Pessoa Pessoa { get; set; }



    }
}