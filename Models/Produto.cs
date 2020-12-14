using System;
using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class Produto : CamposAuditoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string CodProduto { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int TipoProdutoId { get; set; }
        public TipoProduto TipoProduto { get; set; }


    }
}