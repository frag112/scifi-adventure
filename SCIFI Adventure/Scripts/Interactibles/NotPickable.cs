using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScifiAdventure
{
    public class NotPickable : ActionItem
    {
        [SerializeField] private string[] _lines;
        public override void Interact()  // при взаимодействии выдает uihandler текст и запускает проверку на квест у игрока
        {
            PlaySound(_interractSound);
            UIHandler.Instance.RecieveDialogueLines(_lines);
            _player.PlayerInteracts(this);
        }
    }
}