using Microsoft.Extensions.Caching.Distributed;

namespace StudentApp.Repository
{
	public class RedisMemories : IRedisMemories
    {
        private readonly IDistributedCache _distributedCache;

        public RedisMemories(IDistributedCache distributedCache)
		{
            _distributedCache = distributedCache;
		}

        public T GetRedisData<T>(T data,string? cacheName = "student", int? minutesToHide=600)
        {
            var existingTime = _distributedCache.GetString(cacheName);//Daha önceden ilgili key’e ait bir kayıt var mı diye bakılmıştır.
            if (string.IsNullOrEmpty(existingTime)) // Eğer herhangi bir kayıt yok ise koşulu tanımlanmıştır.
            {
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(minutesToHide.Value)); // Burada SetSlidingExpiration() anlamı, Redis’de ilgili key ile belli bir zaman mesela bu örnekte 5sn içinde hiçbir işlem yapılmaz ise, cache’in düşeceğinin belirlenmesidir.
                option.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(minutesToHide.Value); // Burada AbsoluteExpirationRelativeToNow() anlamı, Redis’de ilgili keye ait cache’in mutlaka yani işlem yapılsın ya da yapılmasın 5sn sonunda düşeceğinin belirlenmesidir.
                string name = _distributedCache.GetString("Name"); //Redis’de bash command satırından daha önceden tanımlanan isim, burada çekilmiştir.
                _distributedCache.SetString(cacheName, $"{name}: {data}", option); 
            }
            return (T)(object) _distributedCache.GetString(cacheName);
        }
    }
}

