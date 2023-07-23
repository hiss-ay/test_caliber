using UnityEngine;
using UnityEngine.UI;

namespace Game.Sources.BaseViews
{
    public abstract class BasePopup : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GraphicRaycaster raycaster;
        
        public virtual void Show()
        {
            ShowOrHideScreen(true);
        }

        public virtual void Hide()
        {
            ShowOrHideScreen(false);
        }

        private void ShowOrHideScreen(bool isShowing)
        {
            canvas.enabled = isShowing;
            raycaster.enabled = isShowing;
        }
    }
}