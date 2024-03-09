using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inv
{
    public class UI_Inventory : MonoBehaviour
    {
        private Inventory inventory;
        public Transform itemSlotContainer;
        public Transform itemSlotTemplate;

        private void Awake()
        {
            itemSlotContainer = transform.Find("ItemSlotContainer");
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        }
        public void SetInventory(Inventory inventory)
        {
            this.inventory = inventory;
            RefreshInventoryItems();
        }

        private void RefreshInventoryItems()
        {
            int x = 0;
            int y = 0;
            float itemSlotCellSize = 30f;
             foreach (Item item in inventory.GetItemsList())
             {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                x++;
                if (x > 4)
                {
                    x = 0;
                    y++;
                }
             }
        }
    }
}
