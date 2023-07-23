using Game.Sources.BaseViews;
using UnityEngine;

namespace Game.Sources.ConvertPopup
{
    public class ConvertPopup : BasePopup
    {
        [SerializeField] private ConvertPopupView view;

        private ConvertPopupPresenter _presenter;
        
        private void Awake()
        {
            _presenter = new ConvertPopupPresenter(view);
        }
        
        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }

        public override void Show()
        {
            base.Show();
            _presenter.OnShow();
        }

        public override void Hide()
        {
            base.Hide();
            _presenter.OnHide();
        }
    }
}
