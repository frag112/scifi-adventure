using UnityEngine;

namespace ScifiAdventure
{
    public class NPC : Interactible
    {
        [SerializeField] private string[] dialogue;
        [Header("NPC own components section")]
        [SerializeField] private AudioSource _mouth;

        private Animator _animator;
        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }
        public override void Interact()
        {
            UIHandler.Instance.RecieveDialogueLines(dialogue);
            TriggerAnimations();
        }
        protected virtual void TriggerAnimations()
        {
            _animator.SetTrigger("Talking");

            if (!_mouth.isPlaying)
            {
                _mouth.PlayOneShot(_interractSound);
            }
        }
    }
}