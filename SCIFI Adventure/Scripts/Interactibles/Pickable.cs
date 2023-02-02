using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Pickable : Interactible
    {
        [SerializeField] private Item _item;
        [SerializeField] private Player _player;
        protected override void InterractAction()
        {

            if (_player.PlayerGetsItem(_item))
            {
                PlaySound(this._interractSound);
                Destroy(this.gameObject.GetComponent<MeshFilter>());
                Destroy(this);
            }
            else
            {
                PlaySound(this._noAccessSound);
            }  
        }
    }
}