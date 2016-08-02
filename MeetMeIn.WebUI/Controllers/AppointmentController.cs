using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetMeIn.Domain.Abstract;
using MeetMeIn.Domain.Entities;

namespace MeetMeIn.WebUI.Controllers
{
    public class AppointmentController : Controller
    {
        private IAppointmentRepository repository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            this.repository = appointmentRepository;
        }

        public ViewResult List()
        {
            return View(repository.Appointments);
        }
    }
}