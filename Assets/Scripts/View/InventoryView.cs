using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryView : MonoBehaviour
{
    // Ссылки на элементы, настраиваемые в инспекторе
    [SerializeField] private InventoryController _controller;
    [SerializeField] private Transform _slotsContainer;
    [SerializeField] private GameObject _slotPrefab;

    private void Start()
    {
        // Событие обновления инвентаря и первичная отрисовка
        _controller.OnInventoryUpdated += UpdateView;
        UpdateView();
    }

    private void UpdateView()
    {
        // Удаление старых слотов
        foreach (Transform child in _slotsContainer)
            Destroy(child.gameObject);

        var items = _controller.GetItems(); // Получение текущих предметов
        int maxSlots = _controller.MaxSlots;    // Получение общего количества доступных слотов

        for (int i = 0; i < maxSlots; i++)
        {
            // Добавление нового слота
            var slotGO = Instantiate(_slotPrefab, _slotsContainer);

            // Поиск нужных элементов UI внутри слота
            var icon = slotGO.transform.Find("Icon").GetComponent<Image>();
            var nameTxt = slotGO.transform.Find("Name").GetComponent<TMP_Text>();
            var descTxt = slotGO.transform.Find("Description").GetComponent<TMP_Text>();
            var remBtn = slotGO.transform.Find("RemoveButton").GetComponent<Button>();

            if (i < items.Count)
            {
                // Заполнение слота
                var item = items[i];
                icon.sprite = item.Icon;
                nameTxt.text = item.Name;
                descTxt.text = item.Description;

                // Удаление слушателей
                remBtn.onClick.RemoveAllListeners();

                // Новый обработчик кнопки удаления
                remBtn.onClick.AddListener(() => _controller.RemoveItem(item));
            }
            else
            {
                // Пустой слот: полупрозрачная иконка, скрытая кнопка
                icon.color = new Color(1, 1, 1, 0.3f);
                nameTxt.text = "";
                descTxt.text = "";
                remBtn.gameObject.SetActive(false);
            }
        }
    }

    private void OnDestroy() => _controller.OnInventoryUpdated -= UpdateView;
}
