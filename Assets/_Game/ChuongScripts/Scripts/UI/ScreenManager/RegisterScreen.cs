using System;
using TMPro;
using UnityEngine.UI;

namespace ChuongCustom
{
    public class RegisterScreen : AppScreen
    {
        public TextMeshProUGUI textRemain;

        private void Update()
        {
            UpdateTimeRemain();
        }

        public override ScreenType GetID()
        {
            return ScreenType.RegisterScreen;
        }

        private void UpdateTimeRemain()
        {
            var checkTime = Manager.Register.CheckTime;

            if (checkTime.TotalSeconds < 1)
            {
                textRemain.text = "You need to pay to continue";
                GameDataManager.Instance.playerData.ResetTime();
            }
            else
            {
                string answer = string.Format("{0:D1}Day: {1:D2}h:{2:D2}m:{3:D2}s",
                    checkTime.Days,
                    checkTime.Hours,
                    checkTime.Minutes,
                    checkTime.Seconds);

                textRemain.text = $"Time remaining : " +
                                  $"{answer}";
            }
        }
    }
}