using Application.Common.Abstract;
using Autofac;
using Presistance;
using UI.Helpers;

namespace UI
{
    public class IocModule : Module
    {
        public IocModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbHelper>();
            //builder.RegisterType<>().As<ILogger>();
            //builder.RegisterType<Helper>().As<IHelper>();
        }

    }
}
