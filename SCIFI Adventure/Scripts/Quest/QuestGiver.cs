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
            var combinedDialogues = new string[1];
            switch (dialogues.Count)
            {
                case 0:
                    combinedDialogues[0] = _noQuestsDialogue;
                    //TriggerAnimations(); //bad dialogue audio
                    break;
                case 1:
                    combinedDialogues = new string[dialogues[0].Length + 2];
                    combinedDialogues[0] = "So, this is wahat you have to do.";
                    for(int i = 0; i < dialogues[0].Length; i++)
                    {
                        combinedDialogues[i+1] = dialogues[0][i];
                    }
                    combinedDialogues[dialogues[0].Length + 1] = "Come back, when you finish.";
                    break;
                case 2:
                    combinedDialogues = new string[dialogues[0].Length + 3+ dialogues[1].Length];
                    combinedDialogues[0] = "In case you have forgotten, your first task is:";
                        for (int i = 0; i < dialogues[0].Length; i++)
                        {
                            combinedDialogues[i + 1] = dialogues[0][i];
                        }
                    combinedDialogues[dialogues[0].Length + 1] = "And another one:";
                    for (int i = 0; i < dialogues[1].Length; i++)
                    {
                        combinedDialogues[i + 2 + dialogues[0].Length] = dialogues[1][i];
                    }

                    combinedDialogues[dialogues[0].Length + 2 + dialogues[1].Length] = "Looks like a quite intersting adveture, heh.";
                    //finalLine = ($"Okay.First - {descriptions[0]} Then, {descriptions[1]} It is not so hard, you know.");
                    break;
                default:
                    combinedDialogues[0] = "You not supposed to see this line, I guess the game is broken. Contact creators for help";
                    break;
            }

            UIHandler.Instance.RecieveDialogueLines(combinedDialogues);
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


