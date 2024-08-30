using Microsoft.Extensions.Caching.Memory;

namespace Utility.Providers
{
    public interface ISQLQueryProvider
    {
        public Task<string> GetQuery(string filePath);
    }

    public class SQLQueryProvider: ISQLQueryProvider
    {
        private readonly IMemoryCache _cache;
        //private readonly Assembly _assembly;

        public SQLQueryProvider(IMemoryCache cache)
        {
            _cache = cache;
           // _assembly = Assembly.GetExecutingAssembly();
        }

        public async Task<string> GetQuery(string fileName)
        {

            string fullPath = Path.GetFullPath(fileName);

            if (_cache.TryGetValue(fullPath, out string query))
            {
                return query;
            }

            query = await File.ReadAllTextAsync(fullPath);

            var cacheEntryOprtions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            };

            _cache.Set(fileName, query, cacheEntryOprtions);

            return query;
        }
    }
}
