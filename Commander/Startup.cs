
using Microsoft.EntityFrameworkCore;
using Commander.Data;

namespace Commander
{
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();

        // we will add our registration -> we make use of our Services Collection 
        // After the <> I tell my depency injection system my interface (in our case ICommanderRepo)
        // and it is mapped to our MockCommanderRepo
        services.AddScoped<ICommanderRepo, MockCommanderRepo>();

        // whenever our application asks for ICommanderRepo, give it MockCommanderRepo
        // if this changes in the future all we need to do is swap the MockCommanderRepo with the one we want
        // the rest of our code doesn't change


        //this is where we will configure our DbContext class to use with the rest of the application
        services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer 
        (Configuration.GetConnectionString("CommanderConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}
}

