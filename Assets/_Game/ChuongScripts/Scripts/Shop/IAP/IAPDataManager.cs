using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using static System.String;

namespace ChuongCustom
{
    public class IAPDataManager : SerializedMonoBehaviour
    {
        [OdinSerialize, NonSerialized] private List<IAPData> data;
        private static Dictionary<string, IAPData> _dataDict;

        private void Awake()
        {
            _dataDict = new();
            foreach (var iapData in data)
            {
                _dataDict.Add(iapData.productID, iapData);
            }
        }

        public static IAPData GetData(string productID)
        {
            return _dataDict[productID];
        }

        [Button]
        private void LoadIapKey(IAPData copy, bool removeCache = false)
        {
            if (removeCache || data == null) data = new List<IAPData>();
            var fields =
                typeof(IAPKey).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            foreach (var field in fields)
            {
                var productKey = field.GetValue(null).ToString();
                if(IsNullOrEmpty(productKey)) continue;
                if(data.Any(iapData => iapData.productID == productKey)) continue;
                var newData = (IAPData) Activator.CreateInstance(copy.GetType());
                newData.productID = productKey;
                newData.price = ".99$";
                data.Add(newData);
            }
        }

        /*[Button]
        private void Sort()
        {
            data?.Sort((first, second) => first.amount.CompareTo(second.amount));
        }*/
    }

    [Serializable]
    public class IAPData
    {
        [IAPKey] public string productID;
        public string price;
    }

    [Serializable]
    public class IAPSingleValueData : IAPData
    {
        public int value;
    }
    
    [Serializable]
    public class IAPDoubleValueData : IAPData
    {
        public int value1;
        public int value2;
    }
}



