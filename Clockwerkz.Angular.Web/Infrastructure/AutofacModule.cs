using Autofac;
using Clockwerkz.Application.Jobs.Queries;
using System.Linq;

namespace Clockwerkz.Angular.Web.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ListJobsQueryHanlder).Assembly)
                .Where(x => x.Name.EndsWith("Command") || x.Name.EndsWith("Query") || x.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
