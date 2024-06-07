using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChuongCustom
{
    [DefaultExecutionOrder(10)]
    public class SkinDataManager : PersistentSingleton<SkinDataManager>
    {
        [SerializeField] private List<SkinData> skins;

        private void OnEnable()
        {
            var count = skins.Count - Data.Player.skinUnlocks.Count;
            if (count <= 0)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Data.Player.skinUnlocks.Add(0);
            }
        }

        public List<SkinData> Skins => skins;

        public Sprite CurrentSkin => skins[Data.Player.currentSkin].sprite;
    }

    [Serializable]
    public class SkinData
    {
        public int price;
        public Sprite sprite;
    }
}