var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

IWebHostEnvironment env = builder.Environment;

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

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
