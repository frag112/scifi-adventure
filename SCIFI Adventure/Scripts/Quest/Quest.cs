using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace ScifiAdventure
{
    //[System.Serializable]
    [CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
    public class Quest : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField] private string[] _dialogue, _optionalDialogue, _finishDialogue;
        [SerializeField] public bool _done;

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
    }

    public enum QuestState
    {
        NotActive,
        Active,
        Completed,
        Disabled
    }
}
// make qestwrapper not monobehavior and attach it as array to quest npc
