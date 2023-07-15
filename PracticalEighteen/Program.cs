using Microsoft.EntityFrameworkCore;
using PracticalEighteen.Data.Context;
using PracticalEighteen.Data.Repositories;
using PracticalEighteen.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContextPool<ApplicationDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Set formatter
builder.Services.AddControllers().AddXmlSerializerFormatters();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
