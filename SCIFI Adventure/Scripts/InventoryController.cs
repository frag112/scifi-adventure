using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class InventoryController : MonoBehaviour
    {
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

        }
    }
}