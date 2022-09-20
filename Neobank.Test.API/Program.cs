using Neobank.Test.API.Filters;
using Neobank.Test.API.Models.Options;
using Neobank.Test.Infrastructure.Business;
using Neobank.Test.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddApplications(builder.Configuration);

//UNDONE: consider using options
builder.Services.Configure<FilmSearchServiceOptions>(FilmSearchServiceOptions.IMDB,
    builder.Configuration.GetSection($"{FilmSearchServiceOptions.Section}:{FilmSearchServiceOptions.IMDB}"));

builder.Services.AddControllers(opts =>
    {
        opts.Filters.Add<ResponseFilter>();
        opts.Filters.Add<ExceptionFilter>();
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
