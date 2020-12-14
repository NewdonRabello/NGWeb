using System;
using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class VendaFormaPagamento : CamposAuditoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int TipoFormaPagamentoId { get; set; }
        public TipoFormaPagamento TipoFormaPagamento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de parcelas deve ser maior que zero")]
        public int Parcelas { get; set; }

    }
}