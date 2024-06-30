using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebAppGraphQL.Abstraction;
using WebAppGraphQL.Data;
using WebAppGraphQL.Graph.Mutation;
using WebAppGraphQL.Graph.Query;
using WebAppGraphQL.Mapper;
using WebAppGraphQL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IProductRepository, ProductRepository>(); // AddTransient AddSingleton
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>(); // AddTransient AddSingleton
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.MapGraphQL();

app.Run();
