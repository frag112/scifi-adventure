using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests; 
        [SerializeField] private UIHandler _uiHandler;
        [SerializeField] private InventoryController _inventoryController;
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
            if(_inventoryController.AddItem(item)){
                CheckActiveQests(item.RequiredForQuest());
                return true; 
            }
            return false;
        }
        public bool PlayerGivesItem(Item item)
        {
            if(_inventoryController.RemoveItem(item)){
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
    }
}