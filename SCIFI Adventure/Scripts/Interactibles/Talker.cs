using UnityEngine;
namespace ScifiAdventure{
public class Talker : NPC
{
        [SerializeField] private string[] dialogue;
                public override void Interact()  // запускает анимацию и выдает текст на ui
        {
            UIHandler.Instance.RecieveDialogueLines(dialogue);
            TriggerAnimations();
        }
}
}

