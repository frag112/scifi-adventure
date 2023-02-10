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
        [Tooltip("List of quests this NPC has")]
        [SerializeField] private List<QuestWrapper> _quests;

        [SerializeField] private Player _player;
        [SerializeField] private string _noQuestsDialogue;
        public override void Interact()
        {
            foreach (var quest in _quests)
            {
                if (quest.GetState() == QuestState.Completed)
                {
                    DisableQuest(quest);
                    return;
                }
            }
            QuestWrapper nextQuest = null;
            foreach(QuestWrapper quest in _quests)
            {
                if (quest.GetState() == QuestState.NotActive)
                {
                    nextQuest = quest;
                    break;
                }
            }
            if (_player.CanGetNewQuest() && nextQuest !=null)
            {
                GiveQuest(nextQuest);
                return;
            }
            GiveHelpWithQuests();
        }
        private void GiveHelpWithQuests()
        {
            List<string[]> dialogues = new List<string[]>();

            foreach (var quest in _quests)
            {
                if (quest.GetState() == QuestState.Active)
                {
                    dialogues.Add(quest._quest.GiveOptionalDialogue());
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
                    combinedDialogues.Add("So, this is what you have to do:");
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
        private void GiveQuest(QuestWrapper quest)
        {
                        quest.StartQuest();
                   UIHandler.Instance.RecieveDialogueLines(quest._quest.GiveDialogue());
                        _player.PlayerGetQuest(quest._quest);
                        TriggerAnimations();
        }
        private void DisableQuest(QuestWrapper quest)
        {
            UIHandler.Instance.RecieveDialogueLines(quest._quest.GiveFinishDialogue());
            quest.Disable();
            _player.PlayerFinishQuest(quest._quest);
            //_player.PlayerGivesItem(item);
            TriggerAnimations();
        }
    }

}