using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class ActionItem : Interactible
    {
public override void Interact()
        {
            if (_isInteractible)
            {
                InterractAction();
                SetIntaractState(false);
            }
        }
    }

}


