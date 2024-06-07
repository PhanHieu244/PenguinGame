using UnityEngine;

namespace _Game.ChuongScripts
{
    public class RandomTimeLoopMovement : LoopMovement
    {
        [SerializeField] private float minTime, range;
        protected override float TimeMove()
        {
            return Random.Range(minTime, minTime + range);
        }
    }
}