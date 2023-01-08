using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json.Serialization;
using DatabasesProgrammingExampleSocialNetwork.Database;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(logger);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<EfCoreSocialNetworkContext>();
//builder.Services.AddScoped<IUserWithFriendsRepository, EFCoreUserWithFriendsRepository>();
builder.Services.AddDbContext<EfCoreSocialNetworkContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        o =>
        {
            o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            o.EnableRetryOnFailure();
        });
    options.EnableSensitiveDataLogging();
});

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<EfCoreSocialNetworkContext>();
        context.Database.Migrate();
    }
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

var supportedCultures = new[] { "de-DE", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.Run();
