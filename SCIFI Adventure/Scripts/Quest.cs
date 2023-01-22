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
        [SerializeField] private string _title, _description, _optionalDescription;

        public string GiveDescription()
        {
            return _description;
        }
        public string GiveOptionalDescription()
        {
            return _optionalDescription;
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

