
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDoListAPI.MapperConfig;
using ToDoListAPI.Models;
using ToDoListAPI.Repo;

namespace ToDoListAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(op =>
            {
                op.EnableAnnotations();
                op.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "To-Do List web API ",
                    Version = "v1",
                    Description = " It's a toDoList to track some tasks using deadlines and priorities ",
                    TermsOfService = new Uri("https://github.com/MohamedSalah10010/ToDoListAPI"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed Salah",
                        Email = "mohamedelmorgel2001@gmail.com"
                    }

                });
            });
            builder.Services.AddScoped<TaskRepo>();
            builder.Services.AddDbContext<TaskDBContext>(op=>op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("TasKConnection")));
            // enable Cross-Origin Requests CORS
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });


            // inject AutoMapper Dependancy
            builder.Services.AddAutoMapper(typeof(ToDoListMapperConfig));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);
            app.MapControllers();

            app.Run();
        }
    }
}
