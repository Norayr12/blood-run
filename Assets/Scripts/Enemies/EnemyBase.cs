using System;
using System.Collections.Generic;
using Directions;
using Movements;
using Player;
using Services;
using Services.Terrain;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Enemies
{
    public class EnemyBase : SerializedMonoBehaviour, IEntity
    {
        [SerializeField] private Animator _animator;
        [OdinSerialize] private Dictionary<Direction, string> _animationsNames;
        [SerializeField] private Transform _collidersParent;
        private List<Vector2Int> _patrolPoints;
        private int _currentPositionIndex;
        private Direction _direction;

        public int Health { get; }
        public bool IsAlive { get; }
        public IMovable Movement { get; private set; }
        private LevelService Level => ServiceProvider.Level;

        public void ApplyDamage(IEntity sender, float amount)
        {
            
        }


        public void Initialize(Vector2Int[] patrolPoints, IMovable movement)
        {
            Movement = movement;
            _patrolPoints = new List<Vector2Int>(patrolPoints);
        }

        private void Start()
        {
            transform.position = Level.MainLevel.GetWorldPosition(_patrolPoints[_currentPositionIndex]);
        }

        private void Update()
        {
            Vector2 nextPositionWorld = Level.MainLevel.GetWorldPosition(_patrolPoints[_currentPositionIndex]);
            bool isPlayerInNextPosition = transform.position.x == nextPositionWorld.x && transform.position.y == nextPositionWorld.y;

            if (isPlayerInNextPosition)
            {
                _currentPositionIndex++;
                if (_currentPositionIndex >= _patrolPoints.Count)
                    _currentPositionIndex = 0;
                var direction = (Level.MainLevel.GetWorldPosition(_patrolPoints[_currentPositionIndex]) - (Vector2)transform.position);
                _direction = DirectionUtilities.Vector2DIntToDirection(new Vector2Int((int)direction.normalized.x, (int)direction.normalized.y));
                _animator.Play(_animationsNames[_direction]);
                _collidersParent.rotation = Quaternion.Euler(0, 0, DirectionUtilities.DirectionToAngle(_direction)); 
            }

            Movement.Move(transform, nextPositionWorld, 3 * Time.deltaTime);
        }

    }
}