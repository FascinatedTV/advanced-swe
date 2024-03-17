using Adapter_Repositories;
using Adapter_Store_CSV;
using Application_Code.Interfaces;
using Domain_Code;

CsvRepositoryFactory factory = new();
var repo = factory.GetRepository<Customer>();
Customer c = new Customer()
{
    Id = new Key("1"),
    FirstName = "Niklas",
    LastName = "Haas",
    PassportNumber = "000000000"
};
repo.Add(c);

return;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

EntityManager manager = new EntityManager();
manager.RegisterRepositoryFactory(new CsvRepositoryFactory());

builder.Services.AddSingleton<IEntityManager>(manager);
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();