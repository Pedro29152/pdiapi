using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PdiApi.Models.ResumosFiscais
{
    public enum TipoResumo
    {
        Previsto,
        Recebido
    }

    [DataContract]
    public class Resumo : BaseModel
    {
        public Resumo(decimal SaldoTotal, decimal DividendoTotal, int Ano)
        {
            DataRelatorio = DateTime.Now;
            this.SaldoTotal = SaldoTotal;
            this.DividendoTotal = DividendoTotal;
            this.Ano = Ano;
            SetTotal();
        }

        public Resumo(decimal SaldoTotal, decimal DividendoTotal, int Ano, int Mes)
        {
            DataRelatorio = DateTime.Now;
            this.SaldoTotal = SaldoTotal;
            this.DividendoTotal = DividendoTotal;
            this.Ano = Ano;
            this.Mes = Mes;
            SetTotal();
        }

        public Resumo(decimal SaldoTotal, decimal DividendoTotal, int Ano, int Mes, decimal Total, TipoResumo tipo)
        {
            DataRelatorio = DateTime.Now;
            TipoResumo = tipo;
            this.SaldoTotal = SaldoTotal;
            this.DividendoTotal = DividendoTotal;
            this.Ano = Ano;
            this.Mes = Mes;
            SetTotal(Total);
        }

        [Required]
        [DataMember]
        public DateTime DataRelatorio { get; set; }

        [Required]
        [DataMember]
        public decimal SaldoTotal { get; set; }

        [Required]
        [DataMember]
        public decimal DividendoTotal { get; set; }

        [Required]
        [DataMember]
        public decimal Total { get; private set; }

        [Required]
        [DataMember]
        public int Ano { get; set; }

        [DataMember]
        public int? Mes { get; set; }

        [Required]
        [DataMember]
        public TipoResumo TipoResumo { get; set; }

        private void SetTotal()
        {
            Total = SaldoTotal - DividendoTotal;
        }

        private void SetTotal(decimal Total)
        {
            this.Total = Total;
        }
    }
}
