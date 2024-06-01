using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PobreLibrary.Infrastructure.Persistence;
using PobreLibrary.Application.Services.Implementations;
using PobreLibrary.Application.Services.Interfaces;

namespace PobreLibrary;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("PobreLibraryCs");
        services.AddDbContext<PobreLibraryDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IBookService, BookService>();        
        services.AddControllers();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo() { Title = "PobreLibrary.API", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PobreLibrary.API v1"));
        }
    
        app.UseHttpsRedirection();
    
        app.UseRouting();
    
        app.UseAuthorization();
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // Habilita a configuração de envio de dados do tipo DateTime
    
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
    }

}