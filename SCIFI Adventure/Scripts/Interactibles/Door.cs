using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Animator))]
    public class Door : ActionItem
    {
        private Animator _animator;
        public bool closed = false;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        protected override void InterractAction()
        {
            if (!closed)
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