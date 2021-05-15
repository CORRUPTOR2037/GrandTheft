using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpeechTrigger : MonoBehaviour
{
    public AudioSource source;
    public Speech speech;
    public Door door;
    public bool OneTime = true;
    private bool activated = false;

    void OnTriggerEnter(Collider collider)
    {   
        if (speech == null || !door.Locked) return;
        if (OneTime && activated) return;
        if (collider.gameObject.tag == "Player"){
            SpeechPlayer.Instance.Play(speech, source);
            activated = true;
        }
    }
}
