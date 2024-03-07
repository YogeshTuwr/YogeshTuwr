using Microsoft.OpenApi.Models;
using WebAPI.ApiKeyMiddleware.Middleware;

namespace WebAPI.ApiKeyMiddleware
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
            builder.Services.AddSwaggerGen();

            //            builder.Services.AddSwaggerGen(options =>
            //{
            //    options.AddSecurityDefinition("XApiKey", new ApiKeyScheme
            //    {
            //        Description = "Standard Authorization header using the Bearer scheme. Example: \"{token}\"",
            //        In = "header",
            //        Name = "Authorization",
            //        Type = "apiKey"
            //    });


            //    builder.Services.AddSwaggerGen(options =>
            //    {
            //        options.SwaggerDoc("v1", new OpenApiInfo { Title = "JadeWebAPI", Version = "v1" });

            //        options.AddSecurityDefinition("XApiKey", new OpenApiSecurityScheme
            //        {
            //            Name = "Authorization",
            //            Description = "JWT token must be provided",
            //            In = ParameterLocation.Header,
            //            Type = SecuritySchemeType.Http,
            //            Scheme = "XApiKey"
            //        });

            //        //options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //        //{
            //        //    {
            //        //        new OpenApiSecurityScheme
            //        //        {
            //        //            Name = "Bearer",
            //        //            In = ParameterLocation.Header,
            //        //            Reference = new OpenApiReference
            //        //            {
            //        //                Id="Bearer",
            //        //                Type=ReferenceType.SecurityScheme,
            //        //            }
            //        //        },
            //        //        new string[]{ }
            //        //    }
            //        //});

            //        options.OperationFilter<AuthorizeCheckOperationFilter>();
            //    });






            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "ApiKey must appear in header",
                    Type = SecuritySchemeType.ApiKey,
                    Name = "XApiKey",
                    In = ParameterLocation.Header,
                    Scheme = "ApiKeyScheme"
                });
                var key = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "ApiKey"
                    },
                    In = ParameterLocation.Header
                };
                var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
                c.AddSecurityRequirement(requirement);
            });




            //builder.Services.AddSwaggerGen(opt =>
            //{
            //    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            //    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Description = "Please enter token",
            //        Name = "XApiKey",
            //        Type = SecuritySchemeType.Http,
            //        BearerFormat = "JWT",
            //        Scheme = "bearer"
            //    });
            //    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            //        {
            //            {
            //                new OpenApiSecurityScheme
            //                {
            //                    Reference = new OpenApiReference
            //                    {
            //                        Type=ReferenceType.SecurityScheme,
            //                        Id="Bearer"
            //                    }
            //                },
            //                new string[]{}
            //            }
            //        });
            //});





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseMiddleware<WebAPI.ApiKeyMiddleware.Middleware.ApiKeyMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}