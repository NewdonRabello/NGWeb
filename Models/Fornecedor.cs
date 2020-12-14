using System;
using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class Fornecedor : CamposAuditoria
    {
        public int Id { get; set; }
        public int PessoaId { get; private set; }
        public virtual Pessoa Pessoa { get; set; }

    }
}