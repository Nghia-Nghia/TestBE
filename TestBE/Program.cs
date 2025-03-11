using TestBE.Business.ProductService;
using TestBE.Validator;
using TestBE.Infrastructure;
using TestBE.Shared.Configurations;
using TestBE.Business;
using TestBE.Business.Filters;
using System.Text.Json.Serialization;
using TestBE.Infrastructure.MvcExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options => {
        options.Filters.Add<ModelValidationFilter>();
        options.UseGeneralRoutePrefix("/api");
    })
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.Configure<LimitPurchaseConfiguration>(c =>
    builder.Configuration.GetSection(nameof(LimitPurchaseConfiguration)).Bind(c)
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddBusiness();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddValidatorModel();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
