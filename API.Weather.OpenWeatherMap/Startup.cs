using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Weather.Model;

namespace API.Weather.OpenWeatherMap
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ICurrentWeatherClient, CurrentWeatherClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    CurrentWeatherClient currentWeather = new CurrentWeatherClient(new System.Net.Http.HttpClient(), "https://api.openweathermap.org/data/2.5/weather", "d7432f95eff46ab9d1047f641430710f");
                    WeatherLoad weatherLoad;
                    weatherLoad = await currentWeather.Get("London");
                    //CurrentWeatherResponse currentWeatherResponse;
                    //currentWeatherResponse = await currentWeather.Get("London");
  
                    await context.Response.WriteAsync("Hello World!");
                    await context.Response.WriteAsync(weatherLoad.WeatherReadings[0].Temperature_C.ToString());
                    //await context.Response.WriteAsync(currentWeatherResponse.Main.Temperature.ToString());
                });
            });
        }
    }
}
