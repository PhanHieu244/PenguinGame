using System;
using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public class RegisterManager : PersistentSingleton<RegisterManager>
    {
        private float time = 1;
        private TimeSpan checkTime;

        public TimeSpan CheckTime => checkTime;

        void Update()
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                if (checkTime > TimeSpan.Zero)
                {
                    checkTime = checkTime.Subtract(TimeSpan.FromSeconds(1));
                }

                time = 1;
            }
        }

        void Start()
        {
            checkTime = TimeSpan.FromSeconds(GameDataManager.Instance.playerData.time);

            TimeSpan test =
                DateTime.Now.Subtract(
                    DateTime.FromBinary(Convert.ToInt64(GameDataManager.Instance.playerData.timeRegister)));

            checkTime = checkTime.Subtract(test);

            if (checkTime.TotalSeconds <= 0)
            {
                checkTime = TimeSpan.Zero;
                GameDataManager.Instance.playerData.ResetTime();
            }
        }

        public void AddTime(int i)
        {
            checkTime = checkTime.Add(TimeSpan.FromSeconds(i * 24 * 60 * 60));

            Data.Player.SetTimeRegister((long) checkTime.TotalSeconds);
        }
    }
}