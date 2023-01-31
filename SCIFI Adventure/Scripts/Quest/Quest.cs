using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [System.Serializable]
    public class Quest
    {
        public QuestState _state;
        [SerializeField] public QuestGoal _goal;
        [SerializeField] private string _title, _description;
        [SerializeField] private string[] _dialogue, _optionalDialogue;

        public string[] GiveDialogue()
        {
            return _dialogue;
        }
        public string[] GiveOptionalDialogue()
        {
            return _optionalDialogue;
        }
        public string GiveTitle()
        {
            return _title;
        }
    }

    public enum QuestState
    {
        NotActive,
        Active,
        Completed
    }
}

