using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Enemies
{
    [Serializable]
    public class EnemyContainerWithPatrolPoints
    {
        [SerializeField] private AssetReference _enemyPrefabReference;
        [SerializeField] private Vector2Int[] _patrolPoints;
        public AssetReference EnemyPrefabReference => _enemyPrefabReference;
        public Vector2Int[] PatrolPoints => _patrolPoints;
    }
}