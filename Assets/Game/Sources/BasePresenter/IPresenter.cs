namespace Game.Sources.MainScreen
{
    public interface IPresenter
    {
        void Enable();
        void Disable();

        void OnShow();
        void OnHide();
    }
}