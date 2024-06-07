using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Game.ChuongScripts
{
    public class MonoMovement : MonoBehaviour
    {
        [SerializeField] private Transform movementGroup;
        [SerializeField] private List<Transform> movementPos;
        private Coroutine moveCouroutine;
        public int index;
        public bool isMoving;
        public Action OnMovementCompleted;
        
        [Button]
        private void OnValidate()
        {
            movementPos = movementGroup.GetComponentsInChildren<Transform>().Skip(1).ToList();
        }
        
        private IEnumerator IEMove(Transform mover, Vector2 target, float timeMove)
        {
            isMoving = true;
            Vector2 startPosition = mover.position;
            Vector2 targetPosition = target;
            
            float elapsedTime = 0;

            while (elapsedTime < timeMove)
            {
                mover.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / timeMove);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            mover.position = targetPosition;
            isMoving = false;
            OnMovementCompleted?.Invoke();
        }

        public void MoveNext(Transform target, float timeMove, bool hasLoop = true)
        {
            index++;
            if (index >= movementPos.Count)
            {
                if (!hasLoop)
                {
                    index = movementPos.Count - 1;
                    return;
                }
                index = 0;
            }
            else if (index < 0) index = 0;
            moveCouroutine = StartCoroutine(IEMove(target, movementPos[index].position, timeMove));
        }
        
        public void MoveBack(Transform target, float timeMove, bool hasLoop = true)
        {
            index--;
            if (index >= movementPos.Count) index = movementPos.Count - 1;
            else if (index < 0)
            {
                if (!hasLoop)
                {
                    index = 0;
                    return;
                }

                index = movementPos.Count - 1;
            }
            moveCouroutine = StartCoroutine(IEMove(target, movementPos[index].position, timeMove));
        }

        public void Move(Transform mover, Vector2 target, float timeMove)
        {
            moveCouroutine = StartCoroutine(IEMove(mover, target, timeMove));
        }

        public void StopMove(bool callback = false)
        {
            if (moveCouroutine == null) return;
            StopCoroutine(moveCouroutine);
            isMoving = false;
            if(callback) OnMovementCompleted?.Invoke();
        }
    }
}