using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Animator))] 
    public class QuestGiver : MonoBehaviour
    {
        [SerializeField] private Quest quest;
        private Animator _animator;
        [SerializeField]private AudioSource _mouth;
        [SerializeField] private AudioClip _speech;
        [SerializeField] private UIHandler _uiHandler;

        private void OnEnable()
        {
            _animator= GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _uiHandler.ShowDialogue(quest.GiveDescription());
                _animator.SetTrigger("Talking");
                _mouth.PlayOneShot(_speech);
            }
        }
    }

}


