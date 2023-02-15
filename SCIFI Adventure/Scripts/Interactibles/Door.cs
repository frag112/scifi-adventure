using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Animator))]
    public class Door : ActionItem
    {
        private Animator _animator;
        public bool closed = false;

        protected override void OnEnable()
        {
            base.OnEnable();
            _animator = GetComponent<Animator>();
        }
        public override void Interact()
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

        protected override void Leave()
        {
            _animator.SetBool("character_nearby", false);
        }
    }
}