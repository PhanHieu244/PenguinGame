using UnityEngine;

namespace ChuongCustom
{
    public class ExitGameButton : ButtonClick
    {
        protected override void OnClick()
        {
            Application.Quit();
        }
    }
}