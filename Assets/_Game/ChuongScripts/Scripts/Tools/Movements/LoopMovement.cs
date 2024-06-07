using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.ChuongScripts
{
    [RequireComponent(typeof(MonoMovement))]
    public abstract class LoopMovement : MonoBehaviour
    {
        [SerializeField] private MonoMovement _monoMovement;
        [SerializeField] private Transform mover;

        public MonoMovement Movement => _monoMovement;
        
        private void OnValidate()
        {
            _monoMovement = GetComponent<MonoMovement>();
        }

        protected virtual void OnEnable()
        {
            _monoMovement.OnMovementCompleted += Move;
            Move();
        }

        protected virtual void OnDisable()
        {
            _monoMovement.OnMovementCompleted -= Move;
            _monoMovement.StopMove();
        }

        public void ChangeMover(Transform newMover)
        {
            StopLoop();
            mover = newMover;
            Move();
        }

        public void Move()
        {
            if (mover == null) return;
            _monoMovement.MoveNext(mover, TimeMove());
        }

        public void StopLoop()
        {
            _monoMovement.StopMove();
        }

        protected abstract float TimeMove();
    }
}