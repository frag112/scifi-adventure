using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class InventoryController : MonoBehaviour
    {
        public Transform itemsPanel;
        public List<InventoryItemHolder> slots = new List<InventoryItemHolder>();
        
        private void Start() // добавляет предмет в инвентарь
        {
            for (int i = 0; i < itemsPanel.childCount; i++)
            {
                if (itemsPanel.GetChild(i).GetComponent<InventoryItemHolder>() != null)
                {
                    slots.Add(itemsPanel.GetChild(i).GetComponent<InventoryItemHolder>());
                }
            }
        }

        private void AddItem(Item _item)
        {
            foreach (InventoryItemHolder itemHolder in slots)
            {
                if (itemHolder.item == _item)
                {
                    return;
                }
            }

            foreach (InventoryItemHolder itemHolder in slots)
            {
                if (itemHolder.isEmpty == false)
                {
                    itemHolder.item = _item;
                    itemHolder.isEmpty = false;
                }
            }
        }
    }
}