using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.UI.TooltipLogic
{
    public class TooltipTrigger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private const float TouchDuration = 0.7f;

        public event Action Triggered;

        private CancellationTokenSource _cancellationTokenSource;

        public async void OnPointerDown(PointerEventData eventData)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            float elapsedTime = 0;

            while (elapsedTime < TouchDuration)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    return;
                }

                elapsedTime += Time.deltaTime;
                await Task.Yield();
            }

            Triggered?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}