using UserManagment.Data;
using UserManagment.Presentation.Extensions;
using UserManagment.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Database");
builder.Services.RegisterDatabase(config);
builder.Services.RegisterApplicationServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.WithHeaders("Content-Type");
    });
});

var app = builder.Build();
app.UseCors("AllowCorsPolicy");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbTranslationContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbTranslationContext.Database.EnsureCreated();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
