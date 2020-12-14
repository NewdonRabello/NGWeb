using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NGWebV1.Models
{
    public class Venda : CamposAuditoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
        public ICollection<VendaFormaPagamento> VendaFormaPagamento { get; set; }
        public ICollection<VendaProduto> VendaProduto { get; set; }


        /* Preciso aprender a exibir campo de preenchimento para as variáveis dentro deste "FOR"
        public void AdicionarFormaPagamento(int vendaId, int qtd)
        {
            ICollection<VendaFormaPagamento> nova = new List<VendaFormaPagamento>();
            for (var i = 0; i < qtd; i++)
            {
                int tipoFormaPagamentoId;
                decimal valor;
                int parcelas;
                nova.Add(new VendaFormaPagamento()
                {
                    VendaId = vendaId,
                    TipoFormaPagamentoId = tipoFormaPagamentoId,
                    Valor = valor,
                    Parcelas = parcelas
                });

            }
        }
        */
    }
}


