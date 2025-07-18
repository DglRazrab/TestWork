using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemData")]
public class ItemData : ScriptableObject    // Модель отдельного предмета инвентаря
{
    public string Name; // Название предмета
    [TextArea] public string Description;   // Описание
    public Sprite Icon; // Иконка
}