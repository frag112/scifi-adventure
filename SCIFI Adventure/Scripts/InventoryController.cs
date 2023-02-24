using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class InventoryController : MonoBehaviour
    {
        // куррент селектед - это тот итем на котором сейчас рамка выделения, когда игрок перемещается по инвентарю, сюда вписывается новый итем,
        public Item _currentSelectedItem; // [HideInInspector]
        // после того как игрок нажал на кнопку *комбинировать* над каким то куррент селектед, он должен вписаться в этот лист, лист может хранить не более 2х предметов
        // как это проиходит
        // игрок нажал *комбинировать* над чем-то, прошла проверка, можно ли дописывать в лист. Если он пуст, то дописать. Если есть один предмет, дописать и запустить проверку на комбинирование. и очистить лист
         public List<Item> _itemsToCombine; // когда все будет корректно работать то можно поставить вначале атрибут [HideInInspector] чтоыб глаза не мозолил
        [SerializeField] private List<Item> _items; // все вещи в инвентаре
        [SerializeField] private UIHandler _uiHandler; // будем туда отправлять задания на отрисовку иконок и всякого такого
        public int _inventorySlots; // сколько здесь штук, столько нужно будет отрисовать пустых квадратиков

        [SerializeField] private int _inventoryOccupiedSlots;  // сколько слотов сейчас занято, поставил сериалайз чтобы видеть в инспекторе, изменять не нужно
       // public Transform itemsPanel;
        //public List<InventoryItemHolder> slots = new List<InventoryItemHolder>();
        
        private void Start() // добавляет предмет в инвентарь
        {
            // for (int i = 0; i < itemsPanel.childCount; i++)
            // {
            //     if (itemsPanel.GetChild(i).GetComponent<InventoryItemHolder>() != null)
            //     {
            //         slots.Add(itemsPanel.GetChild(i).GetComponent<InventoryItemHolder>());
            //     }
            // }
        }
        public void PopulateInventoryUI()
        {
           // сделать луп форич _итемс и взять их все картинки, записать в массив иконок 

            // здесь контроллер должен передать иконки
            UIHandler.Instance.ShowInventory(/*массив иконок*/);
        }

        private void AddItem(Item _item)
        {
// забрать логику у плауергетситем

            // foreach (InventoryItemHolder itemHolder in slots)
            // {
            //     if (itemHolder.item == _item)
            //     {
            //         return;
            //     }
            // }

            // foreach (InventoryItemHolder itemHolder in slots)
            // {
            //     if (itemHolder.isEmpty == false)
            //     {
            //         itemHolder.item = _item;
            //         itemHolder.isEmpty = false;
            //     }
            // }


        }
        public void RemoveItem(Item item){
// PlayerGivesItem сюда вставить
        }
        public void CombineItems(Item item1, Item item2){
// взять у игрока
        }

    }

    // 
}