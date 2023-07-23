using System;
using Game.Sources.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Sources.ReservesPopup
{
    public class ConsumablesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text amount;
        [SerializeField] private TMP_Text description;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text price;
        
        public event Action Click;
        
        private void OnEnable()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClick);
        }

        public void SetConsumableUIData(ConsumableUIData data)
        {
            title.text = data.Title;
            icon.sprite = data.Icon;
            description.text = data.Description;
        }

        public void SetAmount(int resourceAmount)
        {
            amount.text = $"{resourceAmount}";
        }

        public void SetPrice(int resourcePrice)
        {
            price.text = $"{resourcePrice}";
        }

        public void ToggleButtonInteractable(bool value)
        {
            button.interactable = value;
        }
        
        private void OnClick()
        {
            ToggleButtonInteractable(false);
            Click?.Invoke();
        }
    }
}