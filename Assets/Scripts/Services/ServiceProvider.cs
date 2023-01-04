using Services.GameData;
using Services.PlayerData;
using Services.Terrain;
using Services.UI;

namespace Services
{
    public static class ServiceProvider
    {
        public static PlayerDataService PlayerData => ServiceLocator.GetService<PlayerDataService>();
        public static GameDataService GameData => ServiceLocator.GetService<GameDataService>();
        public static UIService UIService => ServiceLocator.GetService<UIService>();
        public static LevelService Level => ServiceLocator.GetService<LevelService>();
    }
}