namespace ChuongCustom
{
    public class RetryButton : AButton
    {
        protected override void OnClickButton()
        {
            Manager.InGame.Retry();
        }

        protected override void OnStart()
        {
        }
    }
}