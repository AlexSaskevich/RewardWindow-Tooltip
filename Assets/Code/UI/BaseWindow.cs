using UnityEngine;

namespace Code.UI
{
    public abstract class BaseWindow : MonoBehaviour
    {
        private WindowArgs _windowArgs;

        public static TWindow Get<TWindow>() where TWindow : BaseWindow
        {
            return FindObjectOfType<TWindow>(true);
        }

        protected virtual void Awake()
        {
            gameObject.SetActive(false);
        }

        public void SetArgs(WindowArgs args)
        {
            _windowArgs = args;
        }

        public void Show()
        {
            OnShow();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            OnHide();
            gameObject.SetActive(false);
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