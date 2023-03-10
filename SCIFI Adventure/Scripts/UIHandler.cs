using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.UI;

namespace ScifiAdventure
{
public class UIHandler : MonoBehaviour
{
        public static UIHandler Instance { get; private set; }
        [SerializeField] private GameObject _actionPanel, _pauseMenu, _inventoryMenu, _inventoryItemsPanel;  
        [SerializeField] private Animator _dialogueAnimator, _questAnimator, _actionAnimator; 
        private TMP_Text _dialogueText;  
        private int _dialogueIndex;
        [SerializeField] private List<TMP_Text> _questTexts; 
        [SerializeField] private StarterAssetsInputs _player;
        private List<string> _dialogueLines = new List<string>();
        [HideInInspector] public bool _isDialog = false;

        
        private void Awake()  // проверка на синглтон
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
        public void RecieveDialogueLines(string[] newDialogueLines)  
        {
            _dialogueIndex = 0;
            _dialogueLines = new List<string>(newDialogueLines.Length);
            _dialogueLines.AddRange(newDialogueLines);
            ShowDialogue();
        }
        void OnEnable()
        {
            _dialogueText = _dialogueAnimator.GetComponentInChildren<TMP_Text>();
            _actionAnimator= _actionPanel.GetComponent<Animator>();
        }
        public void ShowActionPanel(bool South = true, bool East = false, bool West = false, bool North = false)
        {
            if (South) _actionPanel.SetActive(true);
        }
        public void ShowDialogue() 
        {
            _isDialog= true;
            _player.SwitchActionControl("Dialogue Navigation");
            _dialogueText.text = _dialogueLines[_dialogueIndex];
            _dialogueAnimator.SetBool("Active", true);
            
            
        }
        public void ContinueDialogue()  
        {
            if (_dialogueIndex  < _dialogueLines.Count -1)
            {
                _dialogueIndex++;
                _dialogueText.text = _dialogueLines[_dialogueIndex];
            }
            else
            {
                SkipDialogue();
            }
        }
        public void SkipDialogue() 
        {
            _dialogueAnimator.SetBool("Active", false);
            _player.SwitchActionControl("Player");
            _isDialog = false;
        }
        public void UpdateQuestList(List<Quest> quests)  
        {
            for (int i = 0; i < 2; i++)
            {
                if (quests.Count > i)
                {
                    _questTexts[i].text = quests[i].GiveTitle();
                }
                else
                {
                    _questTexts[i].text = "No Active Quests";
                }
            }
        }
        public void ShowActiveQuests() 
        {
            if (_questAnimator.GetBool("Active"))
            {
                this._questAnimator.SetBool("Active", false);
            }
            else
            {
                _questAnimator.SetBool("Active", true);
            }

        }
        public void HideInventory()
        {
            _inventoryMenu.SetActive(false);
        }
        public void ShowInventory(Sprite[] itemIcons = null) // показать инвентарь
        {
            List<GameObject> itemHolders = new List<GameObject>();

            for (int i = 0; i < _inventoryItemsPanel.transform.childCount; i++)
            {
                itemHolders.Add(_inventoryItemsPanel.transform.GetChild(i).gameObject);
            }
            _inventoryMenu.SetActive(true);
            for (int i = 0; i < itemIcons.Length; i++)
            {
                var image = itemHolders[i].gameObject.transform.GetChild(0).GetComponent<Image>();
                image.sprite = itemIcons[i];
            }            
        }
        public void ShowHidePauseMenu()
        {
            if (_pauseMenu.activeSelf)
            {
                _pauseMenu.SetActive(false);
            }
            else
            {
                _pauseMenu.SetActive(true);
            }
        }
    }
}

