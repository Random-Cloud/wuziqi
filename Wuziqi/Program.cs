using WuziqiServer.Services.Interfaces;
using WuziqiServer.Services;


var builder = WebApplication.CreateBuilder(args);

            // ×¢²á·þÎñ
builder.Services.AddSingleton<IRoomService, RoomService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();

    