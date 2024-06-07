using System;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    [RequireComponent(typeof(Button))]
    public class ButtonClickAudio : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(MasterAudioManager.ClickSound);
        }
    }
}