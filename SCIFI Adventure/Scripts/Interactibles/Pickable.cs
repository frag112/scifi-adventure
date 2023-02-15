using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class Pickable : ActionItem
    {
        [SerializeField] private Item _item;
        public override void Interact()
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