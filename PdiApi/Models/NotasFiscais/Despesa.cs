using System;
using System.Runtime.Serialization;

namespace PdiApi.Models.NotasFiscais
{
    [DataContract]
    public class Despesa : BaseModel
    {
        public Despesa(string Status, DateTime? DataPagamento)
        {
            string stts = "";

            if (Status == "Agendado")
            {
                stts = "Agendado";
            }
            else if (DataPagamento != null)
            {
                stts = "OK";
            }
            else
            {
                stts = "Pendente";
            }
            this.Status = stts;
            this.DataPagamento = DataPagamento;
        }
        //--------------------------------------Nota Fiscal---------------------------------------
        [DataMember]
        public int CategoriaID { get; set; }
        [DataMember]
        public Categoria Categoria { get; set; }

        [DataMember]
        public int TipoNotaID { get; set; }
        [DataMember]
        public TipoNota Tipo { get; set; }
        
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime? DataPagamento { get; set; }
        [DataMember]
        public DateTime DataEnvio { get; set; }
        //----------------------------------------------------------------------------------------

        //------------------------------------Despesa---------------------------------------------
        [DataMember]
        public string Banco { get; set; }
        
        [DataMember]
        public decimal Valor { get; set; }

        [DataMember]
        public string Descricao { get; set; }
        //----------------------------------------------------------------------------------------
    }
}