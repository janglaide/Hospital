using BLL.Interfaces;
using BLL.Repositories;
using DAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Web
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, 
            Type type)
        {
            return type == null ? null : (IController)kernel.Get(type);
        }
        private void AddBindings()
        {
            kernel.Bind<IDoctorRepository>().To<DoctorRepository>();
            kernel.Bind<IPatientRepository>().To<PatientRepository>();
            kernel.Bind<ISpecializationRepository>().To<SpecializationRepository>();
            kernel.Bind<IVisitRepository>().To<VisitRepository>();
            kernel.Bind<IVisitResultRepository>().To<VisitResultRepository>();

            kernel.Bind<HContext>().ToSelf().WithConstructorArgument("Context",
                ConfigurationManager.ConnectionStrings[0].ConnectionString);

            kernel.Inject(Membership.Provider);
        }
    }
}