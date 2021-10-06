using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DataImporter.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
