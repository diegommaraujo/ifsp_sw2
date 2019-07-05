using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{
    [DataContract]
    public class Consultor
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public int TelefoneId { get; set; }

        [IgnoreDataMember]
        public virtual IEnumerable<Telefone> Telefones { get; set; }
    }
}