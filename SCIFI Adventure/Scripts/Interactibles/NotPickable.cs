using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class NotPickable : ActionItem
    {
        [SerializeField] private string[] _lines;
        public override void Interact()
        {
            PlaySound(_interractSound);
            UIHandler.Instance.RecieveDialogueLines(_lines);
            _player.PlayerInteracts(this);
        }
    }
}