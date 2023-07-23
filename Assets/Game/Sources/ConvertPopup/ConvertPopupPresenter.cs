using System;
using Game.Sources.MainScreen;
using UnityEngine;

namespace Game.Sources.ConvertPopup
{
    public class ConvertPopupPresenter : IPresenter
    {
        private const int GoldRate = 1;
        
        private readonly ConvertPopupView _view;
        
        private Guid _operationGuid = Guid.Empty;

        public ConvertPopupPresenter(ConvertPopupView view)
        {
            _view = view;
        }

        public void Enable()
        {
            _view.Click += ConvertCurrency;
            GameModel.OperationComplete += TryUpdateAmount;
        }

        public void Disable()
        {
            _view.Click -= ConvertCurrency;
            GameModel.OperationComplete -= TryUpdateAmount;
        }

        public void OnShow()
        {
            SetRate();
            UpdateView();
        }
        
        public void OnHide()
        {
            _operationGuid = Guid.Empty;
            _view.ResetView();
        }

        private void TryUpdateAmount(GameModel.OperationResult result)
        {
            if (result.Guid != _operationGuid)
                return;

            if (!result.IsSuccess)
            {
                Debug.Log(result.ErrorDescription);
            }

            UpdateView();
            _view.ToggleButtonInteractable(true);
        }
        
        private void UpdateView()
        {
            _view.SetGoldAmount(GameModel.CoinCount);
            _view.SetCreditAmount(GameModel.CreditCount);
        }
        
        private void SetRate()
        {
            _view.SetRate(GoldRate, GameModel.CoinToCreditRate);
        }
        
        private void ConvertCurrency()
        {
            _operationGuid = GameModel.ConvertCoinToCredit(_view.CoinCountToRate);
        }
    }
}