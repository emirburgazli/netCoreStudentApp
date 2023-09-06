
namespace StudentApp.Repository
{
	public interface IRedisMemories
    {
        T GetRedisData<T>(T data,string? cacheName,int? minutesToHide = 600);
    }
}

