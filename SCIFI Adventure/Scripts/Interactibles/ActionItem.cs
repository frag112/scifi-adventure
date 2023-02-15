using UnityEngine;
namespace ScifiAdventure
{
[RequireComponent(typeof(AudioSource))]
    public class ActionItem : Interactible
    {
    [SerializeField] protected bool _isInteractible;
    [SerializeField] protected AudioClip _interractSound, _noAccessSound;
    protected AudioSource _audioSource;
    public Quest _goal; 
    protected virtual void OnEnable()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    protected virtual void PlaySound(AudioClip sound)
        {
            if (!_audioSource.isPlaying)
            {
                this._audioSource.PlayOneShot(sound);
            }
        }
    public override void Interact()
        {
            PlaySound(this._interractSound);
           _player.PlayerInteracts(this);
        }
    }
}