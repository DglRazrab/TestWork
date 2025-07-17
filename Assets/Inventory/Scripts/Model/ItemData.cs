using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject    // Модель отдельного предмета инвентаря
{
    public string Name;
    [TextArea] public string Description;
    public Sprite Icon;
}