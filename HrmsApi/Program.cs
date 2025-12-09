

using HrmsApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MySQL connection
var conn = builder.Configuration.GetConnectionString("MySqlConn");

builder.Services.AddDbContext<HrmsDbContext>(options =>
{
    options.UseMySql(
        conn,
        new MySqlServerVersion(new Version(8, 0, 36))
    );
});


builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();


