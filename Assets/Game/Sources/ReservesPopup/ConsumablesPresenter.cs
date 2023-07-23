using System;
using Game.Sources.MainScreen;
using UnityEngine;

namespace Game.Sources.ReservesPopup
{
    public class ConsumablesPresenter : IPresenter
    {
        private readonly GameModel.ConsumableTypes _type;
        private readonly ConsumablesView _view;
        
        private Guid _operationGuid = Guid.Empty;

        public ConsumablesPresenter(GameModel.ConsumableTypes type, ConsumablesView view)
        {
            _type = type;
            _view = view;
        }

        public void Enable()
        {
            _view.Click += BuyConsumables;
            GameModel.OperationComplete += TryUpdateAmount;
        }

        public void Disable()
        {
            _view.Click -= BuyConsumables;
            GameModel.OperationComplete -= TryUpdateAmount;
        }
        
        public void OnShow()
        {
            var resourceData = UIHelper.GetConsumableUIData(_type);
            _view.SetConsumableUIData(resourceData);
            
            UpdateAmount();
            UpdatePrice();
        }

        public void OnHide()
        {
            _operationGuid = Guid.Empty;
        }

        private void TryUpdateAmount(GameModel.OperationResult result)
        {
            if (result.Guid != _operationGuid)
                return;

            if (!result.IsSuccess)
            {
                Debug.Log(result.ErrorDescription);
            }

            UpdateAmount();
            _view.ToggleButtonInteractable(true);
        }

        private void UpdateAmount()
        {
            var resourceAmount = GameModel.GetConsumableCount(_type);
            _view.SetAmount(resourceAmount);
        }

        //Ценник не меняется в модели, поэтому решил вызвать всего лишь один,
        //а также я тут не рассматриваю вариант, когда ресурс можно купить за несколько валют (золото, кредиты)
        private void UpdatePrice()
        {
            var priceConfig = GameModel.ConsumablesPrice[_type];
            var price = priceConfig.CoinPrice == 0 ? priceConfig.CreditPrice : priceConfig.CoinPrice;
            
            _view.SetPrice(price);
        }

        private void BuyConsumables()
        {
            _operationGuid = _type switch
            {
                GameModel.ConsumableTypes.Medpack => GameModel.BuyConsumableForGold(_type),
                GameModel.ConsumableTypes.ArmorPlate => GameModel.BuyConsumableForSilver(_type),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}