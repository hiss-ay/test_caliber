using UnityEngine;
using UnityEngine.UI;

namespace Game.Sources.BaseViews
{
    public class CloseButton : MonoBehaviour
    {
        private Button _button;
        private BasePopup _basePopup;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _basePopup = GetComponentInParent<BasePopup>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(CloseCurrentScreen);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CloseCurrentScreen);
        }

        private void CloseCurrentScreen()
        {
            _basePopup.Hide();
        }
    }
}