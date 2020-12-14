using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class Pessoa : CamposAuditoria
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string NomeRazaoSocial { get; set; }
        public bool IsPJ { get; set; }
        public string CpfCnpj { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }



    }
}