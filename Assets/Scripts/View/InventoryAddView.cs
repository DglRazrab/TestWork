using UnityEngine;
using TMPro;

public class InventoryAddView : MonoBehaviour
{
    // Ссылки на элементы, настраиваемые в инспекторе
    [SerializeField] private TMP_Dropdown _itemsDropdown;
    [SerializeField] private InventoryController _controller;

    // Массив всех доступных для добавления предметов
    private ItemData[] _allPossibleItems;

    private void Awake()
    {
        // Загрузка всех ItemData из Resources/Items
        _allPossibleItems = Resources.LoadAll<ItemData>("Items");

        // Заполнение Dropdown
        _itemsDropdown.options.Clear();
        foreach (var item in _allPossibleItems)
            _itemsDropdown.options.Add(new TMP_Dropdown.OptionData(item.Name));
        _itemsDropdown.RefreshShownValue();
    }

    // OnClick кнопки "Добавить предмет"
    public void OnAddButtonClicked()
    {
        var idx = _itemsDropdown.value;
        var item = _allPossibleItems[idx];
        _controller.AddItem(item);
    }
}
