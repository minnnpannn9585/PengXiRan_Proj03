using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Game/Recipe")]
public class Recipe : ScriptableObject
{
    public Item material1; // 材料1
    public Item material2; // 材料2
    public Item result;    // 炼药结果
}