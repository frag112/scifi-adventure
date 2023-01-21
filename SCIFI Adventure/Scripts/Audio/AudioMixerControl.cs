using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace ScifiAdventure
{
    public class AudioMixerControl : MonoBehaviour
    {
        [SerializeField] private AudioMixer _ambientMixer;
        const  float _transitionDuration = 2f;
        public void SwitchSnapshots(AudioMixerSnapshot snapShot, float  transitionDuration = _transitionDuration)
        {
                snapShot.TransitionTo(transitionDuration);
        }
    }
}

