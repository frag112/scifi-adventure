using StarterAssets;
using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(AudioSource))]
    public class Interactible : MonoBehaviour
    {
        [SerializeField] protected bool _isInteractible;
        [SerializeField] protected AudioClip _interractSound, _noAccessSound;
        protected AudioSource _audioSource;
        public Quest _goal;

        private void OnEnable()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<StarterAssetsInputs>().AssignInteractibe(this);
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<StarterAssetsInputs>().AssignInteractibe(null);
                SetIntaractState(true);
                Leave();
            }
        }

        protected virtual void SetIntaractState(bool newState)
        {
            _isInteractible = newState;
        }

        public virtual void Interact()
        {
            if (_isInteractible)
            {
                
                InterractAction();
                SetIntaractState(false);
            }
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
                this._audioSource.PlayOneShot(sound);
            }
        }
    }
}