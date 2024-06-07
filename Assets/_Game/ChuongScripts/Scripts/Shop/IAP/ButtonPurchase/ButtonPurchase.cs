using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public abstract class ButtonPurchase : MonoBehaviour
    {
        [SerializeField, IAPKey] public string productID;
        [SerializeField] public Button buttonClick;
        
        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            Setup();
        }

        protected virtual void Init()
        {
            SetupPurchaseData(IAPDataManager.GetData(productID));
            buttonClick.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
            IAPManager.OnPurchaseSuccess = OnPurchaseSuccess;
            IAPManager.Instance.BuyProductID(productID);
        }
        
        protected abstract void Setup();

        protected abstract void SetupPurchaseData(IAPData iapData);

        protected abstract void OnPurchaseSuccess();

        protected virtual ButtonPurchase GetAnotherIAP()
        {
            var components = GetComponents<ButtonPurchase>();
            return components.FirstOrDefault(buttonPurchase => !ReferenceEquals(this, buttonPurchase));
        }
        
        [Button]
        protected virtual void CopyIAPReferent()
        {
            var another = GetAnotherIAP();
            if (another == null) return;
            Debug.Log($"another iap: {another.GetType().Name}");
            var anotherFields = another.GetType().GetFields().ToDictionary(info => info.Name);
            var fields = GetType().GetFields().ToDictionary(info => info.Name);
            foreach (var (fieldName, fieldInfo) in anotherFields)
            { 
                Debug.Log($"check another field: {fieldName}");
                if(!fields.ContainsKey(fieldName)) continue;
                var value = fieldInfo.GetValue(another);
                if(value == null) continue;
                Debug.Log($"{fieldName} has in {name} has set new value: {value}");
                fields[fieldName].SetValue(this, value);
            }
        }
    }

    public abstract class ButtonPurchase<T> : ButtonPurchase where T : IAPData
    {
        protected override void SetupPurchaseData(IAPData iapData)
        {
            if (iapData is not T trueData)
            {
                Debug.LogError($"iapkey {iapData.productID} is {iapData.GetType().Name} " +
                               $"not match with {typeof(T).Name} in {name}");
                return;
            }
            SetupPurchaseData(trueData);
        }

        protected abstract void SetupPurchaseData(T iapData);
    }
}