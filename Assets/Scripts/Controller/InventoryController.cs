using UnityEngine;
using System;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData; // Ссылка на элемент, настраиваемый в инспекторе

    public event Action OnInventoryUpdated; // Вызывается после добавления или удаления предмета в инвентаре

    // Cвойства инвентаря
    public int MaxSlots => _inventoryData.MaxSlots;
    public int Count => _inventoryData.Items.Count;

    // Доступ к списку элементов
    public IReadOnlyList<ItemData> GetItems()
    {
        return _inventoryData.Items.AsReadOnly();
    }

    public bool AddItem(ItemData item)
    {
        // Проверка: если предмет уже есть, он не добавляется
        if (_inventoryData.Items.Contains(item))
        {
            Debug.LogWarning($"Предмет \"{item.Name}\" уже есть в инвентаре.");
            return false;
        }

        // Проверка: если достигнут лимит слотов, ничего не добавляется
        if (_inventoryData.Items.Count >= _inventoryData.MaxSlots)
        {
            Debug.LogWarning("Инвентарь полон!");
            return false;
        }

        // Добавление предмета
        _inventoryData.Items.Add(item);
        OnInventoryUpdated?.Invoke();
        return true;
    }


    // Удаление элементов инвентаря
    public bool RemoveItem(ItemData item)
    {
        bool removed = _inventoryData.Items.Remove(item);
        if (removed)
            OnInventoryUpdated?.Invoke();
        return removed;
    }
}