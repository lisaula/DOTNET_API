using Autofac;
using Autofac.Core;
using Entity_CodeFirst.context;

namespace WebAPI
{
    internal class DataModule : Module
    {
        private string connStr;

        public DataModule(string v)
        {
            this.connStr = v;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SchoolContext(connStr)).InstancePerRequest();
            /*builder.Register(c => new EFContext(this.connStr)).
                             As<SchoolContext>().InstancePerRequest();

            builder.RegisterType<SqlRepository>().As<IRepository>().InstancePerRequest();
            builder.RegisterType<TeamRepository>().As<ITeamRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();*/
            base.Load(builder);
        }
    }
}