using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ChatModel
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Color { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        [NotMapped]
        public OperationContext operationContext { get; set; }
    }
}
