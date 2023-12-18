using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnionHangfireDB;Integrated Security=True;Pooling=False"));
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.UseAuthorization();
app.MapControllers();
//TODO: Modulate Service
BackgroundJob.Schedule(
    () => Console.WriteLine("Send MAIlS"),
    TimeSpan.FromDays(7));

RecurringJob.AddOrUpdate("Integrate Marketplace",
    () => Console.Write("Recurring"), Cron.Daily);

app.Run();
