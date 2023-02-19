using UnityEngine;
namespace ScifiAdventure
{
[RequireComponent(typeof(AudioSource))]
    public class ActionItem : Interactible
    {
    [SerializeField] protected AudioClip _interractSound, _noAccessSound;
    protected AudioSource _audioSource;
    public Quest _goal; 
    protected virtual void OnEnable()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    protected virtual void PlaySound(AudioClip sound) // если аудиоисточник сейчас не играет, запустить звук
        {
            if (!_audioSource.isPlaying)
            {
                this._audioSource.PlayOneShot(sound);
            }
        }
    public override void Interact()  // вызывается игроком, при нажатии кнопки для взаимодействия
        {
            PlaySound(this._interractSound);
           _player.PlayerInteracts(this);
        }
    }
}