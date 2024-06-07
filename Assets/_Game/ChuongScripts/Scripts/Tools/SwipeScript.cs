using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Movement
{
    using UnityEngine;

    public class SwipeScript : SerializedMonoBehaviour
    {
        [SerializeField] private Direction direction = Direction.VERTICAL;
        [SerializeField] private float speed = 2f;
        [SerializeField] private bool isChangePos;
        [ShowIf("isChangePos"), SerializeField] private bool isLimitHorizontal;
        [ShowIf("isChangePos"), SerializeField] private bool isLimitVertical;
        [ShowIf("isLimitHorizontal"),SerializeField] private float minX, maxX;
        [ShowIf("isLimitVertical"), SerializeField] private float minY, maxY;
        [OdinSerialize, NonSerialized] private ISwipeMovement movement;
        private Camera mainCam;
        private bool isSwipe = false;
        private Vector2 recentTouchPos;
        private float deltaSpeed;

        private void Awake()
        {
            mainCam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            deltaSpeed = speed * Time.deltaTime;
            if (Input.touchCount == 1)
            {
                var touch = Input.touches[0];
                var touchPos = (Vector2) mainCam.ScreenToWorldPoint(touch.position);
                switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            /* this is a new touch */
                            recentTouchPos = touchPos;
                            isSwipe = true;
                            break;

                        case TouchPhase.Canceled:
                            /* The touch is being canceled */
                            isSwipe = false;
                            break;

                        case TouchPhase.Moved:

                            if (isSwipe)
                            {
                                Vector2 swipeType = Vector2.zero;
                                
                                swipeType = (touchPos - recentTouchPos) * deltaSpeed;
                                recentTouchPos = touchPos;

                                if ((direction & Direction.HORIZONTAL) == 0) swipeType.x = 0.0f;
                                if ((direction & Direction.VERTICAL) == 0) swipeType.y = 0.0f;
                                if (isChangePos)
                                {
                                    var newPos = movement.Transform.position;
                                    newPos += (Vector3) swipeType;
                                    
                                    if (isLimitHorizontal)
                                    {
                                        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
                                    }

                                    if (isLimitVertical)
                                    {
                                        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
                                    }

                                    movement.Transform.position = newPos;
                                }
                                if (swipeType.x != 0.0f)
                                {
                                    if (swipeType.x > 0.0f)
                                    {
                                        
                                        //MOVE RIGHT
                                        movement.MoveRight(swipeType.x);
                                    }
                                    else
                                    {
                                        // MOVE LEFT
                                        movement.MoveLeft(swipeType.x);
                                    }
                                }

                                if (swipeType.y != 0.0f)
                                {
                                    if (swipeType.y > 0.0f)
                                    {
                                        // MOVE UP
                                        movement.MoveUp(swipeType.y);
                                    }
                                    else
                                    {
                                        // MOVE DOWN
                                        movement.MoveDown(swipeType.y);
                                    }
                                }
                            }

                            break;
                    }
            }
        }
    }

    public interface ISwipeMovement
    {
        Transform Transform { get; }
        void MoveLeft(float deltaX);
        void MoveRight(float deltaX);
        void MoveUp(float deltaY);
        void MoveDown(float deltaY);
    }

    [Flags]
    public enum Direction
    {
        VERTICAL = 1,
        HORIZONTAL
    }
}