using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Animator))]
    public class QuestGiver : NPC
    {
        [Header("Quest section")]
        [SerializeField] protected bool _canTalk;
        [Tooltip("List of quests this NPC has")]
        [SerializeField] private List<Quest> _quests;

        [SerializeField] private Player _player;
        [SerializeField] private string _noQuestsDialogue;
        public override void Interact()
        {
            var iHaveMoreQuests = false;
            foreach(Quest quest in _quests)
            {
                if (quest._state == QuestState.NotActive)
                {
                    iHaveMoreQuests = true;
                    break;
                }
            }
            if (_player.CanGetNewQuest() && iHaveMoreQuests)
            {
                GiveQuest();
                return;
            }
            GiveHelpWithQuests();
        }
        private void GiveHelpWithQuests()
        {
            List<string[]> dialogues = new List<string[]>();

            foreach (var quest in _quests)
            {
                if (quest._state == QuestState.Active)
                {
                    dialogues.Add(quest.GiveOptionalDialogue());
                }
            }
            var combinedDialogues = new List<string>();
            switch (dialogues.Count)
            {
                case 0:
                    combinedDialogues.Add(_noQuestsDialogue);
                    //TriggerAnimations(); //bad dialogue audio
                    break;
                case 1:
                    combinedDialogues.Add("So, this is wahat you have to do:");
                    combinedDialogues.AddRange(dialogues[0]);
                    combinedDialogues.Add("Come back, when you finish.");
                    break;
                case 2:
                    combinedDialogues.Add("In case you have forgotten, your first task is:");
                    combinedDialogues.AddRange(dialogues[0]);
                    combinedDialogues.Add("And another one:");
                    combinedDialogues.AddRange(dialogues[1]);
                    combinedDialogues.Add("Looks like a quite intersting adveture, heh.");
                    break;
                default:
                    combinedDialogues.Add("You not supposed to see this line, I guess the game is broken. Contact creators for help");
                    break;
            }

            UIHandler.Instance.RecieveDialogueLines(combinedDialogues.ToArray());
            TriggerAnimations();
        }
        private void GiveQuest()
        {

                foreach (var quest in _quests)
                {

                    if (quest._state == QuestState.NotActive)
                    {
                        quest._state = QuestState.Active;
                   UIHandler.Instance.RecieveDialogueLines(quest.GiveDialogue());
                        _player.PlayerGetQuest(quest);
                        TriggerAnimations();
                    break;
                    }
                }

        }

        private void CanTalkNow()
        {
            _canTalk = true;
        }
    }

}


