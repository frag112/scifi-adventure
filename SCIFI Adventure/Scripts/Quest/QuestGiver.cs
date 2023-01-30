using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Animator))]
    public class QuestGiver : Interactible
    {
        [Header("Quest section")]
        [SerializeField] protected bool _canTalk;
        [Tooltip("List of quests this NPC has")]
        [SerializeField] private List<Quest> _quests;
        [Header("NPC own components section")]
        [SerializeField]private AudioSource _mouth;
        [SerializeField] private AudioClip _speech;

        [SerializeField] private Player _player;

        private Animator _animator;

        private void OnEnable()
        {
            _animator= GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_player.CanGetNewQuest())
                {
                    GiveQuest();
                    return;
                }
                GiveHelpWithQuests();
            }
        }
        private void GiveHelpWithQuests()
        {
            List <string> descriptions= new List<string>();
            string finalLine = "";
            foreach (var quest in _quests)
            {
                if (quest._state == QuestState.Active)
                {
                    descriptions.Add(quest.GiveOptionalDescription());
                }
            }
            switch (descriptions.Count)
            {
                case 0:
                    finalLine = "Talk with the other guy";
                    break;
                case 1:
                    finalLine = ($"Like I said, you need to do this.{descriptions[0]} Come back, when you finish.");
                    break;
                case 2:
                    finalLine = ($"Okay.First - {descriptions[0]} Then, {descriptions[1]} It is not so hard, you know.");
                    break;
                default:
                    finalLine = "We are not supposed to talk now";
                    break;
            }
           // UIHandler.Instance.ShowDialogue(finalLine);
            TriggerAnimations();
        }
        private void GiveQuest()
        {

                foreach (var quest in _quests)
                {

                    if (quest._state == QuestState.NotActive)
                    {
                        quest._state = QuestState.Active;
                   // UIHandler.Instance.ShowDialogue(quest.GiveDescription());
                        _player.PlayerGetQuest(quest);
                        TriggerAnimations();
                    break;
                    }
                }

        }
        private void TriggerAnimations()
        {
            _animator.SetTrigger("Talking");

            if (!_mouth.isPlaying)
            {
                _mouth.PlayOneShot(_speech);
            }
        }

        private void CanTalkNow()
        {
            _canTalk = true;
        }
    }

}


