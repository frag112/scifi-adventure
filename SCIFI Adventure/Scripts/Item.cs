using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace ScifiAdventure
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _name, _description;
        [SerializeField] private Sprite _itemIcon;
        [SerializeField] private Item _itemCombineWith, _resultItem;
        [SerializeField] private Quest _requiredForQuest;
        public Quest RequiredForQuest()
        {
            return _requiredForQuest;
        }
        public Item PickedUp()
        {
            return this;
        }
        public Item CombinedWith(Item secondItem)
        {
            if (_itemCombineWith != null && secondItem == _itemCombineWith)
            {
                return _resultItem;
            }
            return null;
        }
        public void UsedUp()
        {
            Destroy(this);
        }
        public string GetName()
        {
            return _name;
        }
        public string GetDescription()
        {
            return _description;
        }
        public Sprite GetIcon()
        {
            return _itemIcon;
        }

    }

}
