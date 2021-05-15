using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened;
    float currentTimer;

    [SerializeField] private AudioSource audioSource;

    [SerializeField]
    private bool _locked;
    public bool Locked {
        get => _locked;
        set {
            _locked = value;
            if (value)
                Close();
            else
                Open();
        }
    }

    public void Open()
    {
        if (_locked) {
            PlayAudio("closed_door");
            return;
        }
        StopAllCoroutines();
        opened = true;
        StartCoroutine(RotateTo(-150));
        audioSource.Stop();
        PlayAudio("open_door");
    }

    public void Close()
    {
        StopAllCoroutines();
        opened = false;
        StartCoroutine(RotateTo(0));
    }

    public void Toggle()
    {
        if (opened)
            Close();
        else
            Open();
    }

    public void Unlock() => Locked = false;

    public void Lock() => Locked = true;

    public void PlayAudio(string id){
        audioSource.PlayOneShot(AudioList.Get(id));
    }

    public void PlayAudio(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }

    private IEnumerator RotateTo(float value)
    {
        Vector3 rot = transform.localEulerAngles;
        float startValue = rot.z; if (startValue > 1) startValue -= 360;
        currentTimer = 0;
        while (currentTimer < 1)
        {
            currentTimer += Time.fixedDeltaTime / 1.0f;
            rot.z = startValue < value ? Mathf.SmoothStep(startValue, value, currentTimer) : Mathf.SmoothStep(value, startValue, 1 - currentTimer);
            transform.localEulerAngles = rot;
            yield return new WaitForFixedUpdate();
        }
    }
}
