using ChatApi.Data;
using ChatApi.Repository;
using ChatApi.Repository.IRepositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

//Add Repsitories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsRules = "CorsRules";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: corsRules, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsRules);

app.UseAuthorization();

app.MapControllers();

app.Run();
