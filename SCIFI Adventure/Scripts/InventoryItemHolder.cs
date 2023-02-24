using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ScifiAdventure{
public class InventoryItemHolder : MonoBehaviour
    {
        public Item item;
        public bool isEmpty = true;
        public GameObject iconGO;

        private void Start()
        {
            iconGO = transform.GetChild(0).gameObject;
        }

        public void SetIcon(Sprite icon) // добавляет иконку в слот 
        {
            iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            iconGO.GetComponent<Image>().sprite = icon;
        }
    }
}

