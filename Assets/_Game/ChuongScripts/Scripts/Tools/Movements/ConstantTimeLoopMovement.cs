using UnityEngine;

namespace _Game.ChuongScripts
{
    public class ConstantTimeLoopMovement : LoopMovement
    {
        [SerializeField] private float timeMove;
        
        protected override float TimeMove()
        {
            return timeMove;
        }
    }
}