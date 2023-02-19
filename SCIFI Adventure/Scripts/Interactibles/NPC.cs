using UnityEngine;

namespace ScifiAdventure
{
    public class NPC : Interactible
    {

        [Header("NPC own components section")]
        [SerializeField] protected AudioClip _interractSound, _noAccessSound;
        [SerializeField] private AudioSource _mouth;

        private Animator _animator;
        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }
        protected virtual void TriggerAnimations()  // запустить анимацию и звук при разговоре
        {
            _animator.SetTrigger("Talking");

            if (!_mouth.isPlaying)
            {
                _mouth.PlayOneShot(_interractSound);
            }
        }
    }
}