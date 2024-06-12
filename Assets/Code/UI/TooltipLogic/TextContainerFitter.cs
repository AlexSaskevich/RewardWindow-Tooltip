using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.TooltipLogic
{
    [Serializable]
    internal struct TextContainerParameters
    {
        [field: SerializeField] public float MinWidth;
        [field: SerializeField] public float MaxWidth;
        [field: SerializeField] public float MinHeight;
        [field: SerializeField] public float MaxHeight;
    }

    public class TextContainerFitter : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransformForChange;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextContainerParameters _textContainerParameters;

        private float _preferredWidth;
        private float _preferredHeight;

        private void OnValidate()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransformForChange);
        }

        private void OnEnable()
        {
            SetSize();
        }

        private void SetSize()
        {
            if (_text == null)
            {
                return;
            }

            _preferredWidth = Mathf.Clamp(_text.preferredWidth, _textContainerParameters.MinWidth,
                _textContainerParameters.MaxWidth);
            _preferredHeight = Mathf.Clamp(_text.preferredHeight, _textContainerParameters.MinHeight,
                _textContainerParameters.MaxHeight);

            _rectTransformForChange.sizeDelta = new Vector2(_preferredWidth, _preferredHeight);

            _text.enableAutoSizing = IsMaxSizeReached();

            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransformForChange);
        }

        private bool IsMaxSizeReached()
        {
            return _rectTransformForChange.sizeDelta.x >= _textContainerParameters.MaxWidth &&
                   _rectTransformForChange.sizeDelta.y >= _textContainerParameters.MaxHeight;
        }
    }
}