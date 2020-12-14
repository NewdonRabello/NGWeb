using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class TipoFormaPagamento : CamposAuditoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string Descricao { get; set; }
        public bool IsParcela { get; set; }

    }
}