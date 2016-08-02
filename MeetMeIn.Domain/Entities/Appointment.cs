using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetMeIn.Domain.Entities
{
    public class Appointment
    {        
        public Guid AppointmentID { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public string Organizer { get; set; }
        public IEnumerable<String> Attandees { get; set; }
        public string Link { get; set; }

        public void Create()
        {
            this.AppointmentID = Guid.NewGuid();
        }
    }
}
