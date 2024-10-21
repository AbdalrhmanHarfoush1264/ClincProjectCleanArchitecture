using ClincProject.Core.MiddleWare;
using ClincProject.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependency Injections
builder.Services.AddInfrastructureDependencies(builder.Configuration)
    .AddServiceDependencies().AddCoreDependencies().AddServiceRegisteration(builder.Configuration);
#endregion

#region CORS
var cors1 = "_cors1";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: cors1,
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleWare>();
app.UseHttpsRedirection();

app.UseCors(cors1);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
