using UnityEngine.SceneManagement;

namespace ChuongCustom
{
    public class PlayButton : ButtonClick
    {
        protected override void OnClick()
        {
            SceneLoader.Instance.LoadScene("GameScene");
        }
    }
}


