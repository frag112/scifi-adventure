using ScifiAdventure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [System.Serializable]
    public class QuestWrapper
    {
        [SerializeField] private QuestState _state;
        [SerializeField] public Quest _quest;
        [SerializeField] private List<GameObject> _activeWithQuest;
        [SerializeField] private List<GameObject> _disableWithQuestEnd;
        [SerializeField] private List<GameObject> _activeWithQuestEnd;
        [SerializeField] private List<GameObject> _disableWithQuest;



        
        public void StartQuest()
        {
            _state = QuestState.Active;
            foreach (var go in _activeWithQuest)
            {
                go.SetActive(true);
            }
            foreach (var go in _disableWithQuest)
            {
                go.SetActive(false);
            }
        }

        public void Complete()
        {
            _state = QuestState.Completed;
            foreach (var go in _disableWithQuestEnd)
            {
                go.SetActive(false);
            }
            foreach (var go in _activeWithQuestEnd)
            {
                go.SetActive(true);
            }
        }
        public void Disable()
        {
            _state = QuestState.Disabled;
        }
        public QuestState GetState()
        {
            return _state;
        }
    }
}

