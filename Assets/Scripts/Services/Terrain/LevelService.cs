using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services.Terrain
{
    public class LevelService : ServiceBase
    {
        [SerializeField] private AssetReference _terrainReference;
        public Level MainLevel { get; private set; }

        public override async UniTask StartAsync()
        {
            GameObject terrainObject = await _terrainReference.InstantiateAsync();
            MainLevel = terrainObject.GetComponent<Level>();
            string terrainName = terrainObject.name.Replace("(Clone)", string.Empty);
            terrainObject.name = terrainName;
            MainLevel.Initialize();
        }
    }
}