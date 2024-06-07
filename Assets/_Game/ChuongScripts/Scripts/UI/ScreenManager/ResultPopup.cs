using UnityEngine;

namespace ChuongCustom
{
    public class ResultPopup : BaseScreenWithModel<ResultModel>
    {
        public override void ShowData()
        {
            
        }
        
        public override ScreenType GetID() => ScreenType.Result;
    }

    public class ResultModel
    {
        public bool isWin;
    }
}