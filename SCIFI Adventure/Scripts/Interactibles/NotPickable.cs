using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class NotPickable : Interactible
    {
        [SerializeField] private Player _player;
        [SerializeField] private string[] _lines;
        protected override void InterractAction()
        {
            PlaySound(_interractSound);
            UIHandler.Instance.RecieveDialogueLines(_lines);
            _player.PlayerInteracts(this);
        }
    }
}