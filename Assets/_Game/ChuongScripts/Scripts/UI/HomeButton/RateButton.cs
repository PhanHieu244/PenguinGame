using UnityEngine;

namespace ChuongCustom
{
    public class RateButton : ButtonClick
    {
        protected override void OnClick()
        {
            RateGame();
        }
        
        private void RateGame()
        {
            MasterAudioManager.ClickSound();
#if UNITY_ANDROID
            Application.OpenURL(string.Format("market://details?id=" + Application.identifier));
#elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/" + Application.identifier);
#endif
            GameDataManager.Instance.playerData.Rated();
        }
    }
}