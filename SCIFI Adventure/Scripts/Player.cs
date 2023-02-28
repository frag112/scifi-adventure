using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests; // список квестов на игроке
        [SerializeField] private UIHandler _uiHandler;
        [SerializeField] private InventoryController _inventoryController;
        public void PlayerGetQuest(Quest quest)  // дает игроку квест если можно
        {
            if (CanGetNewQuest()) 
            {
                _quests.Add(quest);
                _uiHandler.UpdateQuestList(_quests);                
            }
        }
        public void PlayerFinishQuest(Quest quest) // удаляет квест с игрока при его завершении
        {
            _quests.Remove(quest);
            _uiHandler.UpdateQuestList(_quests);
        }
        public bool CanGetNewQuest()
        {
            return (_quests.Count < 2);
        }
        public bool PlayerGetsItem(Item item) // игроку добавляется предмет в инвентарь и проверяется нужен ли он для квеста
        {
            // вот отсюда всю логику унести в инвентари контроллер, пускай он возвращает тру или фалс.
            // если он вернет тру, значит предмет взял и игрок может запустить checkactivequests
                CheckActiveQests(item.RequiredForQuest()); // эту строчку оставить
                return true; 
        }
        public bool PlayerInteracts(ActionItem interactible)  //  при взаимодействии с предметом проверяется, нужен ли он для квеста
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
        
        // player cannot combine items if the inventory is full
        
    }
}

