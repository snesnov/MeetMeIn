using System.Collections.Generic;
using MeetMeIn.Domain.Entities;

namespace MeetMeIn.Domain.Abstract
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> Appointments { get; }
    }
}
