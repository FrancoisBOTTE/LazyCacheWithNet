using LazyCache;
using Microsoft.AspNetCore.Mvc;

namespace LazyCacheWithNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAppCache _cache;

        public WeatherForecastController(IAppCache cache)
        {           
            _cache = cache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<List<string>>> Get()
        {
            Func<Task<List<string>>> stringGet = async () => await LongTaskAndResources.GetLongTask();
            var result = await _cache.GetOrAddAsync("stringKey", stringGet);

            //Cache de 5 minutes
            //var result = await _cache.GetOrAddAsync("stringKey", stringGet, TimeSpan.FromMinutes(5));
            //var result = await _cache.GetOrAddAsync("stringKey", stringGet, DateTimeOffset.Now.AddMinutes(5));

            //remove un élément du cache
            //_cache.Remove("stringKey");

            //retrouver un élément du cache
            //var mesStrings = _cache.Get<List<string>>("stringKey");

            return result;
        }

        [HttpPut(Name = "AddWeatherForecast")]
        public ActionResult<string> Add()
        {
            LongTaskAndResources.AddItem("val4");
            return "Ok";
        }
    }
}