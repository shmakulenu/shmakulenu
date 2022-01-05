using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmailDetails
    {
        public string EAddressSend { get; set; }
        public string ENameSend { get; set; }
        public string EAddressGet { get; set; }
        public string ENameGet { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FileName { get; set; }
    }
}
