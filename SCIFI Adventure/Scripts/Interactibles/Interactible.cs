using StarterAssets;
using UnityEngine;
namespace ScifiAdventure
{
    public class Interactible : MonoBehaviour
    {
    [SerializeField]protected Player _player;  // игрок
        protected virtual void OnTriggerEnter(Collider other)  // проверяет кто вошел в триггерную зону, если это игрок, то вписывает себя ему в пременную интерактибл
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<StarterAssetsInputs>().AssignInteractibe(this);
            }
        }
        protected virtual void OnTriggerExit(Collider other)  // если игрок вышел из зоны действия данного интерактибла, выписать себя из его переменной
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
        // void OnDisable(){
        //     if(_player.GetComponentInChildren<StarterAssetsInputs>()._currentInteractible == this){
        //         _player.GetComponentInChildren<StarterAssetsInputs>().AssignInteractibe(null);
        //     }
       // }
    }
}