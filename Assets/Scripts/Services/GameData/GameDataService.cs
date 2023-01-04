using Cysharp.Threading.Tasks;

namespace Services.GameData
{
    public class GameDataService : ServiceBase
    {
        public override UniTask InitializeAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}