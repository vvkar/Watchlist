using FluentValidation.AspNetCore;
using Neobank.Test.API.Configurations;
using Neobank.Test.API.DI;
using Neobank.Test.API.Filters;
using Watchlist.Infrastructure.Business;
using Watchlist.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddApplications(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddValidators();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient();

builder.Services.ConfigureCustomOptions(builder.Configuration);

builder.Services.ConfigureSwagger(builder.Configuration);

builder.Services
    .AddControllers(opts =>
    {
        opts.Filters.Add<ResponseFilter>();
        opts.Filters.Add<ExceptionFilter>();
        opts.Filters.Add<ValidationFilter>();
    })
    .ConfigureApiBehaviorOptions(opts =>
        opts.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
