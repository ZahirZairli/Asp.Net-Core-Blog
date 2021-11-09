using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageSender { get; set; }
        public string MessageReceiver { get; set; }
        public string Subject { get; set; }
        public string Messagedetail { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
