using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using MeetMeIn.Domain.Abstract;
using MeetMeIn.Domain.Entities;

namespace MeetMeIn.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IAppointmentRepository>().ToConstant(GetMockedAppointmentRepository());
        }

        private IAppointmentRepository GetMockedAppointmentRepository()
        {
            Mock<IAppointmentRepository> mock = new Mock<IAppointmentRepository>();

            mock.Setup(m => m.Appointments).Returns(new List<Appointment> { 
                new Appointment {
                    Location="11th avenue 44/4, East side, Barber Shop 777, NYC, USA",
                    DateTime = new DateTime(2016, 12, 16, 14, 30, 0),
                },
                new Appointment { 
                    Name = "BeerTime", 
                    Description = "Drink a lot in a pub then fo to a club.", 
                    Location ="30th avenue 25/5, Special Bear Pub, West side, NYC, USA" ,
                    DateTime = new DateTime(2016, 11, 10, 21, 30, 0),
                    Organizer = "Big Dave",
                    Attandees = new List<String>{"John Govard", "Tony Varinger", "Big Dave"}
                },
                new Appointment { 
                    DateTime = new DateTime(2016, 11, 8, 14, 0, 0)
                }
            });

            return mock.Object;
        }
    }
}