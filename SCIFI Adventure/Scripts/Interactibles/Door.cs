using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Animator))]
    public class Door : Interactible
    {
        private Animator _animator;
        private void OnEnable()
        {
            _animator= GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }
        
        protected override void InterractAction()
        {
            if (_isInteractible)
            {
                _animator.SetBool("character_nearby", true);
            }
            else
            {
                PlaySound(_noAccessSound);
            }
        }
        protected override void LeaveAction()
        {
            _animator.SetBool("character_nearby", false);        
        }
    }
}

