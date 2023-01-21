using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [System.Serializable]
    public class Quest
    {
        public bool _isActive;
        [SerializeField] private string _title, _description;

        public string GiveDescription()
        {
            return _description;
        }
    }
}

