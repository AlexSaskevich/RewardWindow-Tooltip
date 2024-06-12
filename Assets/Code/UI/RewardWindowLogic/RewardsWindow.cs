using System.Collections.Generic;
using Code.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.RewardWindowLogic
{
    public class RewardsWindow : BaseWindow
    {
        [SerializeField] private RewardItemView _rewardItemViewPrefab;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;

        private List<RewardItemView> _rewardItemViews;

        protected override void Awake()
        {
            base.Awake();
            _closeButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(Hide);
        }

        protected override void OnShow()
        {
            RewardWindowArgs args = GetArgs<RewardWindowArgs>();

            _titleText.text = args.TitleText;
            List<InventoryItem> items = args.InventoryItems;

            _rewardItemViews = new List<RewardItemView>(items.Count);

            for (int i = 0; i < items.Count; i++)
            {
                RewardItemView rewardItemView = Instantiate(_rewardItemViewPrefab, _horizontalLayoutGroup.transform);
                _rewardItemViews.Add(rewardItemView);

                InventoryItem inventoryItem = items[i];
                rewardItemView.Set(inventoryItem.Title, inventoryItem.Description, inventoryItem.Icon);
            }
        }

        protected override void OnHide()
        {
            _rewardItemViews.ForEach(x => Destroy(x.gameObject));
            _rewardItemViews?.Clear();
        }
    }
}