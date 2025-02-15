using API;
using API.Core;
using API.Repositories;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<PurchaseServices>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PurchaseRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DB>();
    db.CreateDatabase();
}



app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
