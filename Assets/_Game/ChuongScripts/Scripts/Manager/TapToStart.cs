using UnityEngine;
using UnityEngine.EventSystems;

namespace ChuongCustom
{
    public class TapToStart : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            InGameManager.Instance.TapToStart();
            Destroy(gameObject);
        }
    }
}