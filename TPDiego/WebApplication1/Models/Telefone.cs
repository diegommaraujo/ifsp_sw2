using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApplication1.Models
{

    [DataContract]
    public class Telefone
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int DDD { get; set; }
        [DataMember]
        public string Numero { get; set; }

        [IgnoreDataMember]
        public virtual Cliente Cliente { get; set; }
    }
}