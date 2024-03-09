using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Inv
{
    public class Inventory
    {
        private List<Item> itemsList;

        public Inventory()
        {
            itemsList = new List<Item>();

            AddItem(new Item { itemType = Item.ItemType.Wood, amount = 3 });
            AddItem(new Item { itemType = Item.ItemType.Stone, amount = 5 });
            Debug.Log(itemsList.Count);
        }

        public void AddItem(Item item)
        {
            itemsList.Add(item);
        }

        public List<Item> GetItemsList()
        {
            return itemsList;
        }

    }
}
