using ASP.NET_34module.Configuration;

namespace ASP.NET_34module
{
    public class Program
    {
        /// <summary>
        /// �������� ������������ �� ����� Json
        /// </summary>
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddJsonFile("JSON/HomeOptions.json").Build();

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

            //����������� ���������� ������������
            builder.Services.Configure<HomeOptions>(Configuration);


            //���� ���� �������� �����-�� ������������ ��������, � �� ���� ���� �������:
            //builder.Services.Configure<Address>(Configuration.GetSection("Address"));

            //���� ���� �������� �����-�� �������� � ���� ����������:
            //builder.Services.Configure<HomeOptions>(j => j.Heating = Heating.Electric);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
            {
                Title = "SmartHome_ASPNetCore_WebApi_6.0",
                Version = "v1"
            }));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //���� ����������� ���������:
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //��� ���� ����������� ��������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}