using UnityEngine;
using System;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData; // ������ �� �������, ������������� � ����������

    public event Action OnInventoryUpdated; // ���������� ����� ���������� ��� �������� �������� � ���������

    // C������� ���������
    public int MaxSlots => _inventoryData.MaxSlots;
    public int Count => _inventoryData.Items.Count;

    // ������ � ������ ���������
    public IReadOnlyList<ItemData> GetItems()
    {
        return _inventoryData.Items.AsReadOnly();
    }

    public bool AddItem(ItemData item)
    {
        // ��������: ���� ������� ��� ����, �� �� �����������
        if (_inventoryData.Items.Contains(item))
        {
            Debug.LogWarning($"������� \"{item.Name}\" ��� ���� � ���������.");
            return false;
        }

        // ��������: ���� ��������� ����� ������, ������ �� �����������
        if (_inventoryData.Items.Count >= _inventoryData.MaxSlots)
        {
            Debug.LogWarning("��������� �����!");
            return false;
        }

        // ���������� ��������
        _inventoryData.Items.Add(item);
        OnInventoryUpdated?.Invoke();
        return true;
    }


    // �������� ��������� ���������
    public bool RemoveItem(ItemData item)
    {
        bool removed = _inventoryData.Items.Remove(item);
        if (removed)
            OnInventoryUpdated?.Invoke();
        return removed;
    }
}