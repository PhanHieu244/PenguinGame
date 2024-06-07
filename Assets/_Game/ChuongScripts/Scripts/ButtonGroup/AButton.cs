using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ChuongCustom
{
    public abstract class AButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
        }
#endif

        private void Start()
        {
            SetListener(OnClickButton);
            OnStart();
            
            _button.onClick.AddListener(MasterAudioManager.ClickSound);
        }

        public void SetListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        protected abstract void OnClickButton();
        protected abstract void OnStart();
    }
}