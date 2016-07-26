using System.Collections.Generic;
using MeetMeIn.Domain.Entities;

namespace MeetMeIn.Domain.Abstract
{
    public interface IAppointmentsRepository
    {
        IEnumerable<Appointment> Appointments { get; }
    }
}
