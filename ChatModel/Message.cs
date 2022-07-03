using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChatModel
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Msg { get; set; }
        
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}
