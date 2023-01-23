using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests;
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
    }
}

