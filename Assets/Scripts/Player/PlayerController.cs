using System.Collections.Generic;
using Directions;
using Enemies;
using Movements;
using Services;
using Services.Terrain;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Player
{
    public class PlayerController : SerializedMonoBehaviour, IEntity
    {
        [OdinSerialize] private Dictionary<Direction, string> _animationsNames;
        [SerializeField] private Animator _animator;
        private Vector2Int _currentPosition = Vector2Int.zero;
        private Vector2Int _nextPosition;
        private Queue<Vector2Int> _nextCellsDirection;
        public int Health { get; private set; }
        public bool IsAlive { get; private set; }
        public IMovable Movement { get; private set; }
        private LevelService LevelService => ServiceProvider.Level;

        public void ApplyDamage(IEntity sender, float amount)
        {
        }

        private void Start()
        {
            _nextPosition = _currentPosition;
            _nextCellsDirection = new Queue<Vector2Int>();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                _nextCellsDirection.Enqueue(Vector2Int.right);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _nextCellsDirection.Enqueue(Vector2Int.left);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _nextCellsDirection.Enqueue(Vector2Int.down);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                _nextCellsDirection.Enqueue(Vector2Int.up);
            }

            Vector2 nextPositionWorld = LevelService.MainLevel.GetWorldPosition(_nextPosition);
            bool isPlayerInNextPosition = transform.position.x == nextPositionWorld.x && transform.position.y == nextPositionWorld.y;

            if (_nextCellsDirection.Count > 0 && isPlayerInNextPosition)
            {
                var direction = _nextCellsDirection.Dequeue();
                var animationName = _animationsNames[DirectionUtilities.Vector2DIntToDirection(direction)];
                Debug.Log(animationName);
                _animator.Play(animationName);
                _nextPosition = _currentPosition + direction;
                _currentPosition = _nextPosition;
            }

            transform.position = Vector2.MoveTowards(transform.position, nextPositionWorld, 10 * Time.deltaTime);
        }
    }
}