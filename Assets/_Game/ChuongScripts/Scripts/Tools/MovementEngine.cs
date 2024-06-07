using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Movement
{
    public class MovementEngine : SerializedMonoBehaviour
    {
        private Coroutine _moveCoroutine;
        [SerializeField] private float engineSpeed;

        public void ChangeSpeed(float speed)
        {
            engineSpeed = speed;
        }

        public void Move(Vector2 direction)
        {
            Move(direction, engineSpeed);
        }
        
        public void Move(Vector2 direction, float speed)
        {
            Stop();
            _moveCoroutine = StartCoroutine(IEMove(direction, speed));
        }

        public void Stop()
        {
            if(_moveCoroutine != null) StopCoroutine(_moveCoroutine);
        }
        
        private IEnumerator IEMove(Vector2 direction, float speed)
        {
            // Normalize the direction to ensure consistent speed
            direction.Normalize();
            engineSpeed = speed;
            // Loop indefinitely until the coroutine is stopped
            while (true)
            {
                // Calculate the movement vector based on direction and speed
                Vector2 movement = direction * engineSpeed * Time.deltaTime;
        
                // Update the mover's position
                transform.position = (Vector2)transform.position + movement;
        
                // Yield until the next frame
                yield return null;
            }
        }
    }
}