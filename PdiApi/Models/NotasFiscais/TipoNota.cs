using PdiApi.Models.NotasFiscais;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PdiApi.Models.NotasFiscais
{
    [DataContract]
    public class TipoNota : BaseModel
    {
        [Required]
        [DataMember]
        public string NomeTipo { get; set; }
        [Required]
        [DataMember]
        public Tipo Tipo { get; set; }

        public List<Receita> NotasReceita { get; set; }
        public List<Despesa> NotasDespesa { get; set; }
    }
}
