using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExam.View
{
    public class ManagerRequestListItem
    {
        public string Id { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string Status { get; set; }
        public string Executor { get; set; }
        public string Color { get; set; }

        public ManagerRequestListItem(string id, string clientName, string clientPhone, string status, string executor, string color)
        {
            this.Id = id;
            this.ClientName = clientName;
            this.ClientPhone = clientPhone;
            this.Status = status;
            this.Executor = executor;
            this.Color = color;
        }
    }
}
