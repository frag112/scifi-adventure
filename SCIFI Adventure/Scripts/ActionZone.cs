using UnityEngine;

namespace ScifiAdventure
{
    [RequireComponent(typeof(Collider))]
    public class ActionZone : MonoBehaviour
    {
        [SerializeField] private bool _buttonPressed;
        [SerializeField] private Interactible _interactible;

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && _buttonPressed)
            {
                _interactible.Interract();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _interactible.Leave();
            }
        }
    }
}