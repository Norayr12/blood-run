using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services.Game
{
    public class GameLogicService : ServiceBase
    {
        [SerializeField] private AssetReference _playerController;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        
        public override async UniTask StartAsync()
        {
            _cinemachineVirtualCamera.Follow = (await _playerController.InstantiateAsync()).transform;
        }
    }
}