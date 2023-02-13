using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class ActionItem : Interactible
    {
        [SerializeField]private Player _player;
public override void Interact()
        {
            if (_isInteractible)
            {
                InterractAction();
                SetIntaractState(false);
            }
        }
               protected override void InterractAction()
        {
            PlaySound(this._interractSound);
           _player.PlayerInteracts(this);
        }
    }


}


