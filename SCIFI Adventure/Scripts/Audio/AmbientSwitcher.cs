using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace ScifiAdventure
{
    public class AmbientSwitcher : MonoBehaviour
    {
        [SerializeField] private AudioMixerSnapshot _snapShot, _defaultSnapShot;
        [SerializeField] private float _transitionTime = 2f;
        [SerializeField] private AudioMixerControl _mixer;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _mixer.SwitchSnapshots(_snapShot, _transitionTime);
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _mixer.SwitchSnapshots(_defaultSnapShot, _transitionTime);
            }
        }
    }
}

