using BICE.DTO;
using BICE.SRV;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton(typeof(IBase_SRV<Materiel_DTO>), new Materiel_SRV());
builder.Services.AddSingleton(typeof(IBase_SRV<Vehicule_DTO>), new Vehicule_SRV());
builder.Services.AddSingleton(typeof(IBase_SRV<Intervention_DTO>), new Intervention_SRV());
builder.Services.AddSingleton(typeof(IBase_SRV<Categorie_DTO>), new Categorie_SRV());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
