using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

namespace Utility.Providers
{
    public interface ISQLQueryProvider
    {
        public Task<string> GetQueryAsync(string fileName, Type typeInTargetNameSpace);
    }

    public class SQLQueryProvider : ISQLQueryProvider
    {
        private readonly IMemoryCache _cache;

        public SQLQueryProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetQueryAsync(string fileName, Type typeInTargetNamespace)
        {
            string resourceName = $"{typeInTargetNamespace.Namespace}.SQL.{fileName}";

            if (_cache.TryGetValue(resourceName, out string query))
            {
                return query;
            }
            
            // If not cached, load the resource from the assembly
            using (Stream resourceStream = typeInTargetNamespace.Assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new FileNotFoundException($"Resource '{resourceName}' not found.");
                }

                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    query = await reader.ReadToEndAsync();
                }
            }

            _cache.Set(fileName, query, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            });

            return query;
        }
    }
}
