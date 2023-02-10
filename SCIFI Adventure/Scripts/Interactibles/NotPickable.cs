using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class NotPickable : Interactible
    {
        [SerializeField] private string[] _lines;
        protected override void InterractAction()
        {
            UIHandler.Instance.RecieveDialogueLines(_lines);
        }
    }
}