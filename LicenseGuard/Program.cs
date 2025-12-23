public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // The License Guard API root endpoint
        app.MapGet("/api/", () => "The License Guard API is running.");
        app.MapControllers();

        app.UseHttpsRedirection();
        app.Run();
    }
}