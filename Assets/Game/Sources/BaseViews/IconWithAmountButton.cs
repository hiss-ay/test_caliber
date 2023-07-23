using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Sources.BaseViews
{
    public class IconWithAmountButton : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text amount;
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

        public void SetAmount(int amount)
        {
            this.amount.text = $"{amount}";
        }
        
        public void SetIcon(Sprite sprite)
        {
            icon.sprite = sprite;
        }
        
        private void OnClick()
        {
            Click?.Invoke();
        }
    }
}