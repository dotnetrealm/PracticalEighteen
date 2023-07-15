
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//HTTP client configurations
builder.Services.AddHttpClient("studentapi",client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("API_URL"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    //Global exception handler
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Error pages handler
app.UseStatusCodePagesWithReExecute("/Student/PageNotFound");
app.UseRouting();

//Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
