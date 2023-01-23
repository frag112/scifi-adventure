using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(AudioSource))]
    public class Interactible : MonoBehaviour
    {
        [SerializeField] protected bool _isInteractible;
        [SerializeField] protected AudioClip _interractSound, _noAccessSound;
        protected AudioSource _audioSource;

        private void OnEnable()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public void Interract()
        {
            InterractAction();
        }
        
        public void Leave()
        {
            LeaveAction();
        }
        protected virtual void InterractAction()
        {
            Debug.Log("You triggered some action");
        }
        protected virtual void LeaveAction()
        {
            Debug.Log("You triggered some  leave action");
        }
        
        protected virtual void PlaySound(AudioClip sound)
        {

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(sound);
            }
        }
    }
}

