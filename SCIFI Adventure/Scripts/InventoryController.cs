using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class InventoryController : MonoBehaviour
    {
        public Item _currentSelectedItem; // [HideInInspector]
        // после того как игрок нажал на кнопку *комбинировать* над каким то куррент селектед, он должен вписаться в этот лист, лист может хранить не более 2х предметов
        // как это проиходит
        // игрок нажал *комбинировать* над чем-то, прошла проверка, можно ли дописывать в лист. Если он пуст, то дописать. Если есть один предмет, дописать и запустить проверку на комбинирование. и очистить лист
         public List<Item> _itemsToCombine;
        [SerializeField] private List<Item> _items;
        [SerializeField] private UIHandler _uiHandler;
        public int _inventorySlots = 10;
        [SerializeField] private int _inventoryOccupiedSlots;

        public void PopulateInventoryUI()
        {
            List<Sprite> icons = new List<Sprite>();
            foreach (Item item in _items)
            {
                icons.Add(item.GetIcon());
            }
            UIHandler.Instance.ShowInventory(icons.ToArray());
        }

        public bool AddItem(Item _item)
        {
            if (_inventoryOccupiedSlots < _inventorySlots)
            {
                _items.Add(_item);
                _inventoryOccupiedSlots++;
                return true;
            }
            return false;
        }
        public bool RemoveItem(Item item)
        {
            foreach (var currentItem in _items)
            {
                if (currentItem == item)
                {
                    _items.Remove(currentItem);
                    _inventoryOccupiedSlots--;
                    return true;
                }
            }
            return false;
        }
        public void CombineItems(Item item1, Item item2)
        {
            if (RemoveItem(item1.CombinedWith(item2)))
            {
                RemoveItem(item1);
                RemoveItem(item2);
            }
        }
    }
}