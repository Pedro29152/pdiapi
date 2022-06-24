using PdiApi.Models.Contratos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PdiApi.Models.NotasFiscais
{
    [DataContract]
    public class Cliente : BaseModel
    {
        [Required]
        [DataMember]
        public string NomeCliente { get; set; }

        public List<Receita> Receitas { get; set; }
        public List<Contrato> Contratos { get; set; }
    }
}
