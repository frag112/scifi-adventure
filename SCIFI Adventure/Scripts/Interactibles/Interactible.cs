using StarterAssets;
using UnityEngine;
namespace ScifiAdventure
{
    public class Interactible : MonoBehaviour
    {
    [SerializeField]protected Player _player;
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
                Leave();
            }
        }
        public virtual void Interact()
        {

        }

        protected virtual void Leave()
        {
            
        }
    }
}