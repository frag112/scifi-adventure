using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScifiAdventure
{
public class UIHandler : MonoBehaviour
{
        [SerializeField] private GameObject _dialoguePanel;
        private Animator _dialogueAnimator;
        private TMP_Text _dialogueText;

        void OnEnable()
        {
            _dialogueText = _dialoguePanel.GetComponentInChildren<TMP_Text>();
            _dialogueAnimator = _dialoguePanel.GetComponent<Animator>();
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
    }
}

