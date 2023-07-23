using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Sources.MainScreen
{
    public class ConvertGoldToCreditView : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldAmount;
        [SerializeField] private TMP_Text creditAmount;
        [SerializeField] private Button button;
        
        public event Action Click;
        
        private void OnEnable()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClick);
        }

        public void SetGoldAmount(int amount)
        {
            goldAmount.text = $"{UIHelper.IntegerToString(amount)}";
        }
        
        public void SetCreditAmount(int amount)
        {
            creditAmount.text = $"{UIHelper.IntegerToString(amount)}";
        }
        
        private void OnClick()
        {
            Click?.Invoke();
        }
    }
}