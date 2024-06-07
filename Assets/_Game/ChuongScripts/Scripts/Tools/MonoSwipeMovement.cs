using Sirenix.OdinInspector;
using UnityEngine;

namespace Movement
{
    public class MonoSwipeMovement : SerializedMonoBehaviour, ISwipeMovement
    {
        [SerializeField] private SpriteRenderer renderer;
        
        public Transform Transform => transform;

        public void MoveLeft(float deltaX)
        {
            renderer.flipX = false;
        }

        public void MoveRight(float deltaX)
        {
            renderer.flipX = true;
        }

        public void MoveUp(float deltaY)
        {
            
        }

        public void MoveDown(float deltaY)
        {
            
        }
    }
}