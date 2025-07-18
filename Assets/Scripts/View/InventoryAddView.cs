using UnityEngine;
using TMPro;

public class InventoryAddView : MonoBehaviour
{
    // ������ �� ��������, ������������� � ����������
    [SerializeField] private TMP_Dropdown _itemsDropdown;
    [SerializeField] private InventoryController _controller;

    // ������ ���� ��������� ��� ���������� ���������
    private ItemData[] _allPossibleItems;

    private void Awake()
    {
        // �������� ���� ItemData �� Resources/Items
        _allPossibleItems = Resources.LoadAll<ItemData>("Items");

        // ���������� Dropdown
        _itemsDropdown.options.Clear();
        foreach (var item in _allPossibleItems)
            _itemsDropdown.options.Add(new TMP_Dropdown.OptionData(item.Name));
        _itemsDropdown.RefreshShownValue();
    }

    // OnClick ������ "�������� �������"
    public void OnAddButtonClicked()
    {
        var idx = _itemsDropdown.value;
        var item = _allPossibleItems[idx];
        _controller.AddItem(item);
    }
}
