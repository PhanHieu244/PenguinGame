namespace ChuongCustom
{
    public abstract class BaseScreenWithModel<TModel> : BaseScreen
    {
        protected TModel _model;
        public abstract void ShowData();

        public void BindData(TModel model)
        {
            _model = model;
            ShowData();
        }
    }
}