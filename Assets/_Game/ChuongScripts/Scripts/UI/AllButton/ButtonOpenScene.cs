namespace ChuongCustom
{
    using System.Collections;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class ButtonOpenScene : ButtonClick
    {
        [ValueDropdown("GetAllSceneName")] public string sceneName;
        [SerializeField] private bool hasLoading = false;

        private static IEnumerable GetAllSceneName()
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                var name = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                yield return new ValueDropdownItem(name, name);
            }
        }

        protected override void OnClick()
        {
            OpenScene();
        }

        private void OpenScene()
        {
            if (!hasLoading)
            {
                SceneManager.LoadScene(sceneName);
                return;
            }

            SceneLoader.Instance.LoadScene(sceneName);
        }
    }
}