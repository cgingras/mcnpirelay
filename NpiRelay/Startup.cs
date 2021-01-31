using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json.Serialization;

using NpiRelay.Services;

namespace NpiRelay
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public const string PdfViewerPolicy = "MyPolicy";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers()
				.AddNewtonsoftJson(options =>
			{
				// Use the default property (Pascal) casing
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
			});

			services.AddScoped<IRepository>(service => new Repository(Configuration));
			services.AddScoped<INpiService, NpiService>();

			services.AddMemoryCache();

			services.AddCors(options =>
			{
				options.AddPolicy(PdfViewerPolicy,
				builder =>
				{
					builder.AllowAnyOrigin()
					  .AllowAnyMethod()
					  .AllowAnyHeader();
				});
			});

			services.Configure<PdfConfig>(Configuration.GetSection("PdfConfig"));
			services.AddHttpClient<IPdfService, PdfService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//Register Syncfusion license
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Configuration["PdfViewerLicenceKey"]);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCors(PdfViewerPolicy);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
