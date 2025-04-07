using System.Reflection;
using SaveApis.Common.Domains.Hangfire.Infrastructure.Extensions;
using SaveApis.Web.Domains.Core.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var hangfireType = builder.Configuration.GetHangfireType();
var backend = builder.Configuration.IsBackend();
builder.WithAssemblies(Assembly.GetExecutingAssembly()).WithSaveApis(hangfireType, backend);

var app = builder.Build();

await app.RunSaveApisAsync(backend).ConfigureAwait(false);
