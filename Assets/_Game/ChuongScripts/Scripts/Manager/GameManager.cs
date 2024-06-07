using Sirenix.OdinInspector;
using UnityEngine;

namespace ChuongCustom
{
    public static class GameConstant
    {
        public static readonly int TimeWin = 15 * 60;
    }

    public partial class GameManager : PersistentSingleton<GameManager>
    {

        [Button]
        public void Test()
        {
        }
    }
}