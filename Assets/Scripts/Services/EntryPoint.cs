using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.GameData;
using Services.PlayerData;
using Services.Terrain;
using Services.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<ServiceBase> _services = new List<ServiceBase>();


        private void Start()
        {
            StartAsync().Forget();
        }

        private async UniTask StartAsync()
        {
            foreach (var service in _services)
            {
                await service.InitializeAsync();
            }

            foreach (var service in _services)
            {
                ServiceLocator.AddService(service);
            }

            foreach (var service in _services)
            {
                await service.StartAsync();
            }
        }
    }
}
