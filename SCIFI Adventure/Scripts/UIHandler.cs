using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScifiAdventure
{
public class UIHandler : MonoBehaviour
{
        [SerializeField] private GameObject _dialoguePanel, _questPanel;
        private Animator _dialogueAnimator, _questAnimator;
        private TMP_Text _dialogueText;
        [SerializeField] private List<TMP_Text> _questTexts;
        void OnEnable()
        {
            _dialogueText = _dialoguePanel.GetComponentInChildren<TMP_Text>();
            _dialogueAnimator = _dialoguePanel.GetComponent<Animator>();
            _questAnimator= _questPanel.GetComponent<Animator>();
        }

        public void ShowDialogue(string line)
        {      
            _dialogueText.text = line;
            _dialogueAnimator.SetBool("Active", true);
            
            Invoke("HideDialogue", 10);
        }
        void HideDialogue()
        {
            _dialogueAnimator.SetBool("Active", false);
            
        }
        public void UpdateQuestList(List<Quest> quests)
        {
            for (int i = 0; i < quests.Count; i++)
            {
                _questTexts[i].text = quests[i].GiveTitle();
            }
        }
        public void ShowActiveQuests()
        {
            _questAnimator.SetBool("Active", true);
            Invoke("HideQuests", 10);
        }
        void HideQuests()
        {
            _dialogueAnimator.SetBool("Active", false);
        }
    }
}

