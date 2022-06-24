using System;
using System.Runtime.Serialization;

namespace PdiApi.Models
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}
