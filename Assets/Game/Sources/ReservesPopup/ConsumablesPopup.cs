using Game.Sources.BaseViews;
using UnityEngine;

namespace Game.Sources.ReservesPopup
{
    public class ConsumablesPopup : BasePopup
    {
        [SerializeField] private ConsumablesView medpackPanel;
        [SerializeField] private ConsumablesView armorPlatePanel;

        private ConsumablesPresenter _medpackPresenter;
        private ConsumablesPresenter _armorPlatePresenter;
        
        private void Awake()
        {
            _medpackPresenter = new ConsumablesPresenter(GameModel.ConsumableTypes.Medpack, medpackPanel);
            _armorPlatePresenter = new ConsumablesPresenter(GameModel.ConsumableTypes.ArmorPlate, armorPlatePanel);
        }

        private void OnEnable()
        {
            _medpackPresenter.Enable();
            _armorPlatePresenter.Enable();
        }

        private void OnDisable()
        {
            _medpackPresenter.Disable();
            _armorPlatePresenter.Disable();
        }

        public override void Show()
        {
            base.Show();
            _medpackPresenter.OnShow();
            _armorPlatePresenter.OnShow();
        }
        
        public override void Hide()
        {
            base.Hide();
            _medpackPresenter.OnHide();
            _armorPlatePresenter.OnHide();
        }
    }
}