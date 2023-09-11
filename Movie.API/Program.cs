var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Connection DataBase
var ConnectionString = builder.Configuration.GetConnectionString("ApllicationConnection");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(ConnectionString));
#endregion

#region Cors
builder.Services.AddCors();
#endregion

#region Dependency Injection
builder.Services.AddScoped<IGener, GenerRepo>();
/*builder.Services.AddScoped<IMovie, MovieRepo>();*/
#endregion

#region Auto Mapper
builder.Services.AddAutoMapper(option => option.AddProfile(new DomainProfile()));
#endregion
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
#region Cors
app.UseCors(option => option
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
