using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.TooltipLogic
{
    public class TooltipWindow : BaseWindow
    {
        [SerializeField] private TextContainerFitter _textContainerFitter;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;

        protected override void OnShow()
        {
            TooltipWindowArgs args = GetArgs<TooltipWindowArgs>();

            _icon.sprite = args.Icon;
            _title.text = args.Title;
            _description.text = args.Description;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) == false)
            {
                Hide();
            }
        }

        protected override void OnHide()
        {
            float descriptionFontSizeMax = _description.fontSizeMax;
            _description.enableAutoSizing = false;
            _description.fontSize = descriptionFontSizeMax;
        }
    }
}