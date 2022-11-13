using LazyCache;
using LazyCacheWithNetWithoutDI;

IAppCache cache = new CachingService();

//Function pour appeler la longue tache mais ne l'exécute pas ici
Func<Task<List<string>>> stringGet = async() => await LongTaskAndResources.GetLongTask();

//on exécute la fonction et on la met en cache
var timer = new System.Diagnostics.Stopwatch();
var stringsWithCaching = await cache.GetOrAddAsync("stringKey", stringGet);
timer.Stop();
Console.WriteLine($"{stringsWithCaching.Count} strings trouvés en {timer.Elapsed.TotalSeconds} seconde(s)");

//on exécute la fonction une nouvelle fois
timer.Restart();
stringsWithCaching = await cache.GetOrAddAsync("stringKey", stringGet);
timer.Stop();
Console.WriteLine($"{stringsWithCaching.Count} strings trouvés en {timer.Elapsed.TotalSeconds} seconde(s)");