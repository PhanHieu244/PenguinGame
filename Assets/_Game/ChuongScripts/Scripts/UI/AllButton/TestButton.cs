using UnityEngine;

namespace ChuongCustom
{
    public class TestButton : MonoBehaviour
    {
        public void OpenScreen()
        {
            ScreenManager.Instance.OpenScreen(ScreenType.Result, new ResultModel()
            {
                isWin = false
            });
        }
    }
}