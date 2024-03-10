using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCraftRecipe", menuName = "Inventory System/CraftRecipes/CraftRecipe")]
public class CraftRecipe : ScriptableObject
{
    public List<ItemObject> materials; // 需要的材料
    public ItemObject result; // 合成結果
}
