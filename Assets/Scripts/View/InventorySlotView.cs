using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotView : MonoBehaviour
{
    // Ссылки на элементы, настраиваемые в инспекторе
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Button _removeButton;

    // Локальные данные для текущего слота
    private ItemData _item;
    private InventoryController _controller;

    public void Setup(ItemData item, InventoryController controller)
    {
        _item = item;   // Данные предмета для отображения
        _controller = controller;   //Контроллер инвентаря для удаления

        // Заполнение полей UI
        _icon.sprite = item.Icon;
        _name.text = item.Name;
        _description.text = item.Description;

        // Сброс старых и назначение новых слушателей для удаления
        _removeButton.onClick.RemoveAllListeners();
        _removeButton.onClick.AddListener(() =>
        {
            _controller.RemoveItem(_item);
        });
    }
}