using PdiApi.Models.Contratos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PdiApi.Models.NotasFiscais
{
    [DataContract]
    public class Receita : BaseModel
    {
        public Receita(DateTime? DataPagamento, 
            decimal? ValorBanco, 
            DateTime DataVencimento, 
            string Status)
        {
            string stts;
            if (Status == "Cancelado")
            {
                stts = "Cancelado";
            }
            else if (DataPagamento != null && ValorBanco > 0)
            {
                if (DataPagamento.Value > DataVencimento)
                {
                    stts = "Pago Atrasado";
                }
                else
                {
                    stts = "OK";
                }
            }
            else if (DateTime.Now.AddDays(-1) > DataVencimento)
            {
                stts = "Atrasado";
            }
            else
            {
                stts = "Pendente";
            }
            this.DataPagamento = DataPagamento;
            this.ValorBanco = ValorBanco;
            this.DataVencimento = DataVencimento;
            this.Status = stts;
        }

        //--------------------------------------Nota Fiscal---------------------------------------
        /*
        [DataMember]
        public int CategoriaID { get; set; }
        [DataMember]
        public Categoria Categoria { get; set; }
        
        [Required]
        [DataMember]
        public int TipoNotaID { get; set; }
        [DataMember]
        public TipoNota Tipo { get; set; }
        //*/
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime? DataPagamento { get; set; }
        [DataMember]
        public DateTime DataEnvio { get; set; }
        //----------------------------------------------------------------------------------------

        //------------------------------------Receita---------------------------------------------
        [Required]
        [DataMember]
        public string CNPJ { get; set; }
        [Required]
        [DataMember]
        public int NroNota { get; set; }
        [Required]
        [DataMember]
        public DateTime DataEmissao { get; set; }
        [DataMember]
        public decimal? ValorBanco { get; set; }
        [DataMember]
        public string Observacao { get; set; }

        [Required]
        [DataMember]
        public decimal Valor { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public DateTime DataVencimento { get; set; }


        [DataMember]
        public Guid? ContratoID { get; set; }
        [DataMember]
        public Contrato Contrato { get; set; }

        [Required]
        [DataMember]
        public Guid ClienteID { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        //----------------------------------------------------------------------------------------

        public override string ToString()
        {
            return $"{CNPJ} {NroNota} {Valor} {Cliente.NomeCliente}";
        }
    }
}
