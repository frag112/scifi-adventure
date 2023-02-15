using UnityEngine;
namespace ScifiAdventure{
public class Talker : NPC
{
        [SerializeField] private string[] dialogue;
                public override void Interact()
        {
            UIHandler.Instance.RecieveDialogueLines(dialogue);
            TriggerAnimations();
        }
}
}

