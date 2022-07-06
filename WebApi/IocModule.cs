using Application.Common.Abstract;
using Autofac;
using Presistance;

namespace WebApi
{
    public class IocModule : Module
    {
        public IocModule()
        {
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbHelper>();
        }
    }
}
