using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public enum ItemType
{
    Default,    //預設道具
    Story,      //故事道具(將不會消耗)
    Craftable,  //可合成道具
    Consumable, //消耗品

}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
