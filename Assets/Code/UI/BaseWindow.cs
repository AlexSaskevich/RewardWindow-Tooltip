using UnityEngine;

namespace Code.UI
{
    public abstract class BaseWindow : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        private WindowArgs _windowArgs;

        public static TWindow Get<TWindow>() where TWindow : BaseWindow
        {
            return FindObjectOfType<TWindow>(true);
        }

        protected virtual void Awake()
        {
            _canvas.enabled = false;
        }

        public void SetArgs(WindowArgs args)
        {
            _windowArgs = args;
        }

        public void Show()
        {
            OnShow();
            _canvas.enabled = true;
        }

        public void Hide()
        {
            OnHide();
            _canvas.enabled = false;
        }

        protected TArgs GetArgs<TArgs>() where TArgs : WindowArgs
        {
            if (_windowArgs == null)
            {
                Debug.LogError($"Trying to receive {typeof(TArgs)} - NULL args");
                return null;
            }

            return (TArgs)_windowArgs;
        }

        protected abstract void OnShow();
        protected abstract void OnHide();
    }
}