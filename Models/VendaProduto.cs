using System;
using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class VendaProduto : CamposAuditoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public decimal ValorProduto { get; set; }
        public decimal Desconto { get; set; }


    }
}