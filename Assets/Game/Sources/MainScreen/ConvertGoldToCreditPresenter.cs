namespace Game.Sources.MainScreen
{
    public class ConvertGoldToCreditPresenter : IPresenter
    {
        private readonly ConvertGoldToCreditView _view;
        private readonly MainScreen _mainScreen;

        public ConvertGoldToCreditPresenter(MainScreen mainScreen, ConvertGoldToCreditView view)
        {
            _mainScreen = mainScreen;
            _view = view;
        }

        public void Enable()
        {
            OnShow();
            
            GameModel.ModelChanged += UpdateView;
            _view.Click += ShowConvertPopup;
        }

        public void Disable()
        {
            OnHide();
            
            GameModel.ModelChanged -= UpdateView;
            _view.Click -= ShowConvertPopup;
        }

        public void OnShow()
        {
            UpdateView();
        }

        public void OnHide()
        {
            
        }

        private void UpdateView()
        {
            _view.SetGoldAmount(GameModel.CoinCount);
            _view.SetCreditAmount(GameModel.CreditCount);
        }

        private void ShowConvertPopup()
        {
            _mainScreen.ShowConvertPopup();
        }
    }
}