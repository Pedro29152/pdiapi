using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PdiApi.Models.NotasFiscais
{
    public enum Tipo
    {
        Despesa = 1,
        Receita = 2
    };

    [DataContract]
    public class Categoria : BaseModel
    {
        [Required]
        [DataMember]
        public string NomeCategoria { get; set; }

        [Required]
        [DataMember]
        public Tipo TipoCategoria{ get; set; }

        public List<Despesa> NotasDespesa { get; set; }
        public List<Receita> NotasReceita { get; set; }
    }
}
