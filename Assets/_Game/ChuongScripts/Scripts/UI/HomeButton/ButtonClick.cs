using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonClick : SerializedMonoBehaviour
    {
        protected Button _button;

        protected virtual void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();

#if UNITY_EDITOR
        [Button]
        private void AddSound()
        {
            var sound = GetComponent<ButtonClickAudio>();
            if (sound != null) return;
            gameObject.AddComponent<ButtonClickAudio>();
        }
#endif
    }
}