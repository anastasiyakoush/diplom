using AutoMapper;
using BLL.Interfaces;
using BLL.Profiles;
using BLL.Services;
using Common.Dtos;
using DAL.DAL;
using DAL.Entities;
using DiplomApi.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseOpenApi();

      app.UseSwaggerUi3();
    }
  }
}
