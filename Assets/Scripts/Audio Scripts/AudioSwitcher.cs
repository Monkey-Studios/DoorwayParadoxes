using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    [SerializeField] AudioSource enabledTrack;
    [SerializeField] AudioSource disabledTrack;
    [SerializeField] AudioSource PuzzleHint;
    private void OnTriggerEnter(Collider triggerCol)
    {
        if (triggerCol.tag == ("Player"))
        {
            enabledTrack.enabled = false;
            disabledTrack.enabled = true;
            PuzzleHint.enabled = true;
        }
    }
}
