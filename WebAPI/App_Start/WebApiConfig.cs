using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Quartz;
using Quartz.Impl;
using WebAPI.Jobsfolder;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
           name: "Route",
           routeTemplate: "api/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional }

           );



            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
                     
            //    );


        

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.EnableCors(new EnableCorsAttribute( "http://localhost:4200", "*", "*"));


            StdSchedulerFactory factory = new StdSchedulerFactory();

            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();

            IJobDetail jobDetail = JobBuilder.Create<MailJob>().Build();

            ITrigger trigger = TriggerBuilder.Create().StartAt(DateTime.Now.AddSeconds(20)).WithSimpleSchedule(x => x.WithIntervalInSeconds(5)).Build();


            scheduler.ScheduleJob(jobDetail, trigger).GetAwaiter().GetResult();

            scheduler.Start().GetAwaiter().GetResult();
        }
    }
}
