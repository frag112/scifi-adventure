using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [System.Serializable]
    public class Quest
    {
        [SerializeField] private QuestState _state;
        [SerializeField] public QuestGoal _goal;
        [SerializeField] private string _title;
        [SerializeField] private string[] _dialogue, _optionalDialogue, _finishDialogue;
        [SerializeField] private List<GameObject> _activeWithQuest;
        [SerializeField] private List<GameObject> _disableWithQuestEnd;
        [SerializeField] private List<GameObject> _disableWithQuest;

        public string[] GiveDialogue()
        {
            return _dialogue;
        }
        public string[] GiveOptionalDialogue()
        {
            return _optionalDialogue;
        }
        public string[] GiveFinishDialogue()
        {
            return _finishDialogue;
        }
        public string GiveTitle()
        {
            return _title;
        }
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
        }
        public void Disable()
        {
            _state = QuestState.Disabled;
        }
        public QuestState GetState()
        {
            return _state;
        }
        /// public void remove "this" item form player inventory on completion
        /// track player progress, or trigger completion



    }

    public enum QuestState
    {
        NotActive,
        Active,
        Completed,
        Disabled
    }
}

