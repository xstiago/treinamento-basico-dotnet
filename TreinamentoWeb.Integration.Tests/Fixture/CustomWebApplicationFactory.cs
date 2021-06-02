using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Api;
using Xunit;

namespace TreinamentoWeb.Integration.Tests.Fixture
{
    [CollectionDefinition("Startup")]
    public class CustomWebApplicationFactoryCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>> { }

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
        }
    }
}
