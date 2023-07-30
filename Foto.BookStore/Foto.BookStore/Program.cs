using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

IWebHostEnvironment env = builder.Environment;

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),RequestPath= "/MyStaticFiles"
//});
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    //endpoints.MapGet("/", async context =>
    //{
    //    if (env.IsProduction())
    //    {
    //        await context.Response.WriteAsync("Hello from dev!");
    //    }
        
    //});
   
});

app.Run();
