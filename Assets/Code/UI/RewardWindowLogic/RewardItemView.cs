using Code.UI.TooltipLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.RewardWindowLogic
{
    public class RewardItemView : MonoBehaviour
    {
        [SerializeField] private TooltipTrigger _tooltipTrigger;
        [SerializeField] private Image _icon;

        private TooltipWindowArgs _tooltipWindowArgs;
        private string _title;
        private string _description;

        private void OnEnable()
        {
            _tooltipTrigger.Triggered += OnTriggered;
        }

        private void OnDisable()
        {
            _tooltipTrigger.Triggered -= OnTriggered;
        }

        public void Set(string title, string description, Sprite icon)
        {
            _title = title;
            _description = description;
            _icon.sprite = icon;
            _tooltipWindowArgs = new TooltipWindowArgs(_title, _description, _icon.sprite);
        }

        private void OnTriggered()
        {
            TooltipWindow tooltipWindow = BaseWindow.Get<TooltipWindow>();
            tooltipWindow.SetArgs(_tooltipWindowArgs);
            tooltipWindow.Show();
        }
    }
}