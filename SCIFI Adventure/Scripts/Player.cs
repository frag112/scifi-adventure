using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<Quest> _quests; // список квестов на игроке
        [SerializeField] private List<Item> _items; // список вещей на игроке, после перноса можно удалить
        [SerializeField] private UIHandler _uiHandler;
        [SerializeField] private InventoryController _inventoryController;
        public int _inventorySlots; // после переноса удалить
        [SerializeField] private int _inventoryOccupiedSlots; // после переноса удалить
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
            // 
            if (_inventoryOccupiedSlots < _inventorySlots)
            {
                _items.Add(item);
                _inventoryOccupiedSlots++;
                CheckActiveQests(item.RequiredForQuest());// эту строчку оставить
                return true;
            }
            return false;
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
        public bool PlayerGivesItem(Item item)  // должна запускаться при выполнении квеста где нужен этот предмет
        {
            // отсюда все забрать в инвентарь контроллер
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

        // вот этот метод можно целиком унести, здесь его лучше не оставлять
        public void PlayerCombinesItems(Item item1, Item item2)// проверка можно ли скомбинировать предметы и создание нового и удаление старых в случае удачи, можно сделать чтобы возвращала бул чтобы ui отображал невозможность комбинирования например
        {
            if (PlayerGetsItem(item1.CombinedWith(item2)))
            {
                PlayerGivesItem(item1);
                PlayerGivesItem(item2);
            }
        }
    }
}

