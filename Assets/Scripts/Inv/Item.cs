using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inv
{
    public class Item
    {
        public enum ItemType
        {
            Wood,
            Stone,
            Gold,
            Diamond
        }

        public ItemType itemType;
        public int amount;
    }

}
