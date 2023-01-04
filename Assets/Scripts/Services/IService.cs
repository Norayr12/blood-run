using Cysharp.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        UniTask InitializeAsync();

        UniTask StartAsync();

        UniTask StopAsync();
    }
}