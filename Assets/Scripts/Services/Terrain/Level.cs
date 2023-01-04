using Cysharp.Threading.Tasks;
using Enemies;
using Movements;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services.Terrain
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private EnemyContainerWithPatrolPoints[] _enemies;

        public async void Initialize()
        {
            foreach (var enemy in _enemies)
            {
                var spawnedEnemy = await enemy.EnemyPrefabReference.InstantiateAsync();
                spawnedEnemy.GetComponent<EnemyBase>().Initialize(enemy.PatrolPoints, new MoveTowardsMovement());
            }
        }

        public Vector2 GetWorldPosition(Vector2Int axialPosition)
        {
            return _grid.GetCellCenterLocal((Vector3Int)axialPosition);
        }

        public Vector2Int GetAxialPosition(Vector2 worldPosition)
        {
            return (Vector2Int)_grid.LocalToCell(worldPosition);
        }
    }
}