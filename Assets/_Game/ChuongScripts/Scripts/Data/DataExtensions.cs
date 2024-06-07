namespace ChuongCustom
{
    public static class Data
    {
        public static PlayerData Player => GameDataManager.Instance.playerData;
        public static SettingData Setting => GameDataManager.Instance.settingData;
    }
}