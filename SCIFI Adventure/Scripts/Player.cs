using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests;
        [SerializeField] private List<Item> _items;
        [SerializeField] private UIHandler _uiHandler;
        public int _inventorySlots;
        [SerializeField] private int _inventoryOccupiedSlots;
        public void PlayerGetQuest(Quest quest)
        {
            if (CanGetNewQuest()) 
            {
                _quests.Add(quest);
                _uiHandler.UpdateQuestList(_quests);                
            }
        }
        public void PlayerFinishQuest(Quest quest)
        {
            _quests.Remove(quest);
            _uiHandler.UpdateQuestList(_quests);
        }
        public bool CanGetNewQuest()
        {
            return (_quests.Count < 2);
        }
        public bool PlayerGetsItem(Item item)
        {
            if (_inventoryOccupiedSlots < _inventorySlots)
            {
                _items.Add(item);
                _inventoryOccupiedSlots++;
                CheckActiveQests(item.RequiredForQuest());
                return true;
            }
            return false;
        }
        public bool PlayerInteracts(ActionItem interactible)
        {
            if (interactible._goal != null)
            {
                CheckActiveQests(interactible._goal);
                return true;
            }
            return false;
        }
        public void CheckActiveQests(Quest goal)
        {
            foreach (var quest in _quests)
            {
                if (quest == goal)
                {
                    quest._done = true; // let quest giver check this value
                }
            }
        }
        public bool PlayerGivesItem(Item item)
        {
            foreach (var currentItem in _items)
            {
                if(currentItem == item)
                {
                _items.Remove(currentItem);
                    _inventoryOccupiedSlots--;
                    return true;
                }
            }
            return false;
        }
        // player cannot combine items if the inventory is full
        public void PlayerCombinesItems(Item item1, Item item2)
        {
            if (PlayerGetsItem(item1.CombinedWith(item2)))
            {
                PlayerGivesItem(item1);
                PlayerGivesItem(item2);
            }
        }
    }
}

