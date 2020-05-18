using AutoMapper;
using BLL.Interfaces;
using BLL.Profiles;
using BLL.Services;
using Common.Dtos;
using DAL.DAL;
using DAL.Entities;
using DiplomApi.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DiplomApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddAutoMapper(cfg =>
      {
        cfg.AddProfile<BLLProfile>();
        cfg.AddProfile<APIProfile>();
      },
      typeof(BLLProfile), typeof(APIProfile));

      services.AddDbContext<ApplicationContext>(options
          => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

      services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationContext>();
      services.Configure<IdentityOptions>(options =>
      {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 4;
        options.Password.RequiredUniqueChars = 0;

        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
      });
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
        .AddJwtBearer(options =>
        {
          options.RequireHttpsMetadata = false;
          options.SaveToken = true;
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Some secret key for jwt token")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
          };
        });

      services.AddSwaggerDocument();

      services.AddTransient<ITeacherService, TeacherService>();
      services.AddTransient<ISubjectService, SubjectService>();
      services.AddTransient<IDocumentService, DocumentService>();
      services.AddTransient<IPlanService, PlanService>();
      services.AddTransient<IPublicLessonService, PublicLessonService>();
      services.AddTransient<ICrudService<SpecialnostDto>, CrudService<SpecialnostDto, Specialnost>>();
      services.AddTransient<ICrudService<CiklovayaKomissiyaDto>, CrudService<CiklovayaKomissiyaDto, CiklovayaKomissiya>>();
      services.AddTransient<ICrudService<PositionDto>, CrudService<PositionDto, Position>>();
      services.AddTransient<ICrudService<DocumentTypeDto>, CrudService<DocumentTypeDto, DocumentType>>();
      services.AddTransient<ICrudService<GroupDto>, CrudService<GroupDto, Group>>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwaggerUi3();

      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCookiePolicy();
      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseOpenApi();

    }
  }
}
