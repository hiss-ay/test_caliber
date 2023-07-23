using Game.Sources.BaseViews;

namespace Game.Sources.MainScreen
{
    public class ConsumablesPresenter : IPresenter
    {
        private readonly GameModel.ConsumableTypes _type;
        private readonly IconWithAmountButton _view;
        
        private readonly MainScreen _mainScreen;

        public ConsumablesPresenter(MainScreen mainScreen, GameModel.ConsumableTypes type, IconWithAmountButton view)
        {
            _mainScreen = mainScreen;
            _type = type;
            _view = view;
        }

        public void Enable()
        {
            OnShow();
            
            GameModel.ModelChanged += UpdateView;
            _view.Click += ShowReservePopup;
        }

        public void Disable()
        {
            OnHide();
            
            GameModel.ModelChanged -= UpdateView;
            _view.Click -= ShowReservePopup;
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
            var resourceData = UIHelper.GetConsumableUIData(_type);
            var resourceAmount = GameModel.GetConsumableCount(_type);
            
            _view.SetIcon(resourceData.Icon);
            _view.SetAmount(resourceAmount);
        }

        private void ShowReservePopup()
        {
            _mainScreen.ShowReservesPopup();
        }
    }
}
