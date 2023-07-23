using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Sources.ConvertPopup
{
    public class ConvertPopupView : MonoBehaviour
    {
        [SerializeField] private TMP_Text creditRateText;
        [SerializeField] private TMP_Text goldRateText;
        
        [SerializeField] private TMP_Text goldAmount;
        [SerializeField] private TMP_Text creditAmount;

        [SerializeField] private TMP_InputField field;
        [SerializeField] private TMP_Text creditResult;
        
        [SerializeField] private Button button;

        private int _coinCountToRate;
        public int CoinCountToRate => _coinCountToRate;

        public event Action Click;
        
        private void OnEnable()
        {
            field.onValueChanged.AddListener(OnValueChangedHandler);
            button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            field.onValueChanged.RemoveListener(OnValueChangedHandler);
            button.onClick.RemoveListener(OnClick);
        }

        public void SetRate(int goldRate, int creditRate)
        {
            goldRateText.text = $"{goldRate}";
            creditRateText.text = $"{creditRate}";
        }

        public void SetGoldAmount(int amount)
        {
            goldAmount.text = $"{UIHelper.IntegerToString(amount)}";
        }
        
        public void SetCreditAmount(int amount)
        {
            creditAmount.text = $"{UIHelper.IntegerToString(amount)}";
        }
        
        public void ToggleButtonInteractable(bool value)
        {
            button.interactable = value;
        }

        public void ResetView()
        {
            field.text = $"0";
        }
        
        private void OnValueChangedHandler(string value)
        {
            if (int.TryParse(value, out _coinCountToRate))
            {
                var result = _coinCountToRate * GameModel.CoinToCreditRate;
                creditResult.text = UIHelper.IntegerToString(result);
            }
            else
            {
                creditResult.text = "";
            }
        }
        
        private void OnClick()
        {
            ToggleButtonInteractable(false);
            Click?.Invoke();
        }
    }
}