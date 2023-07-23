using Game.Sources.BaseViews;
using UnityEngine;

namespace Game.Sources.MainScreen
{
    //Я не стал наследвоать класс от BasePopup, так как решил, что пусть этот класс будет точкой входа проекта,
    //поэтому методы OnShow и OnHide в презентерах этого окна вызваются прям в Enable и Disable
    public class MainScreen : MonoBehaviour
    {
        [SerializeField] private BasePopup consumablesPopup;
        [SerializeField] private IconWithAmountButton medpackPanel;
        [SerializeField] private IconWithAmountButton armorPlatePanel;

        [SerializeField] private BasePopup convertPopup;
        [SerializeField] private ConvertGoldToCreditView convertPanel;

        private ConsumablesPresenter _medpackPresenter;
        private ConsumablesPresenter _armorPlatePresenter;

        private ConvertGoldToCreditPresenter _convertGoldToCreditPresenter;

        private void Awake()
        {
            _medpackPresenter = new ConsumablesPresenter(this, GameModel.ConsumableTypes.Medpack, medpackPanel);
            _armorPlatePresenter = new ConsumablesPresenter(this, GameModel.ConsumableTypes.ArmorPlate, armorPlatePanel);
            
            _convertGoldToCreditPresenter = new ConvertGoldToCreditPresenter(this, convertPanel);
        }

        private void OnEnable()
        {
            _medpackPresenter.Enable();
            _armorPlatePresenter.Enable();
            
            _convertGoldToCreditPresenter.Enable();
        }

        private void OnDisable()
        {
            _medpackPresenter.Disable();
            _armorPlatePresenter.Disable();
            
            _convertGoldToCreditPresenter.Disable();
        }

        public void ShowReservesPopup()
        {
            consumablesPopup.Show();
        }

        public void ShowConvertPopup()
        {
            convertPopup.Show();
        }

        private void Update()
        {
            GameModel.Update();
        }
    }
}