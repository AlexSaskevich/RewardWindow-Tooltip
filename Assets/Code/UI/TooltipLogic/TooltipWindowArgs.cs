using UnityEngine;

namespace Code.UI.TooltipLogic
{
    public class TooltipWindowArgs : WindowArgs
    {
        public string Description { get; private set; }
        public string Title { get; private set; }
        public Sprite Icon { get; private set; }

        public TooltipWindowArgs(string title, string description, Sprite icon)
        {
            Description = description;
            Title = title;
            Icon = icon;
        }
    }
}