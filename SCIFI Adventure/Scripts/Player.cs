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
        public void PlayerGetQuest(Quest quest)
        {
            if (CanGetNewQuest()) 
            {
                _quests.Add(quest);
                _uiHandler.UpdateQuestList(_quests);
            }
        }
        public bool CanGetNewQuest()
        {
            return (_quests.Count < 2);
        }
        public void PlayerGetsItem(Item item)
        {
            _items.Add(item);
        }
    }
}

