using Interview.Repository.Implementations;
using Interview.Repository.Interfaces;
using Interview.Service.Implementations;
using Interview.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace Interview.Service
{
    public class DependencyConfiguration
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IProfileRepository,ProfileRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<ILoggerRepository, LoggerRepository>();
            container.RegisterType<IProfileService, ProfileService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<ILoggerService, LoggerService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
