using UnityEngine;

namespace ChuongCustom
{
    public static class GameServices
    {
        public static readonly Quaternion RotIdentity = Quaternion.Euler(0, 0f, 0f);
    }

    public static class Manager
    {
        public static ScreenManager ScreenManager => ScreenManager.Instance;
        public static OutGameManager OutGame => OutGameManager.Instance;
        public static InGameManager InGame => InGameManager.Instance;
        public static GameManager Game => GameManager.Instance;
        public static ToastManager Toast => ToastManager.Instance;
        public static RegisterManager Register => RegisterManager.Instance;
    }
}