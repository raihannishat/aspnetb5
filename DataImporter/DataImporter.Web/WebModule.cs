using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Web.Models.GoogleReCAPTCHA;

namespace DataImporter.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GoogleReCaptchaService>().AsSelf()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
