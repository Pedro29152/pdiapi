using PdiApi.Models.NotasFiscais;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace PdiApi.Models.Contratos
{
    [DataContract]
    public class Contrato : BaseModel
    {
        [Required]
        [DataMember]
        public string Descricao { get; set; }
        [Required]
        [DataMember]
        public DateTime DataInicio { get; set; }
        [Required]
        [DataMember]
        public int DuracaoContrato { get; set; }
        [Required]
        [DataMember]
        public decimal Valor { get; set; }
        [Required]
        [DataMember]
        public string CNPJ { get; set; }

        [DataMember]
        public string ArquivoContrato { get; set; }
        [DataMember]
        public string ArquivoProposta { get; set; }
        
        [Required]
        [DataMember]
        public Guid ClienteID { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }

        public List<Receita> Receitas { get; set; }
        //*/
    }
}
