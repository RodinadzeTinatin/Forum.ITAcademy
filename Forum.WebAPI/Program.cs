
using Forum.Service;

namespace Forum.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddDatabaseContext();
            builder.Services.AddSingleton(MappingInitializer.Initialize());
            builder.ConfigureJwtOptions();
            builder.AddIdentity();
            builder.AddAuthentication();
            builder.AddHttpContextAccessor();
            builder.AddScopedServices();
            builder.AddControllers();
            builder.AddEndpointsApiExplorer();
            builder.AddSwagger();
            builder.AddCors();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors(builder.Configuration.GetValue<string>("Cors:AllowOrigin"));
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
