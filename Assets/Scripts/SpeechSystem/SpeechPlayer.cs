using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechPlayer : MonoBehaviour
{
    public static SpeechPlayer Instance { get; private set; }

    public TextMeshProUGUI subtitlesText;

    void Awake(){
        Instance = this;
    }

    private AudioSource currentSource;

    public void Play(Speech speech, AudioSource source){
        currentSource = source;
        if (source != null && speech.Sound != null)
            source.PlayOneShot(speech.Sound);
        
        if (PlayerPrefs.GetString("language") == "ru")
            subtitlesText.text = speech.SubtitlesRus;
        else
            subtitlesText.text = speech.SubtitlesEng;
        subtitlesText.gameObject.SetActive(true);
        
        StopAllCoroutines();
        StartCoroutine(OnSpeechEnd(speech));
    }

    IEnumerator OnSpeechEnd(Speech speech){
        yield return new WaitForSeconds(speech.Duration);
        if (speech.Next != null) Play(speech.Next, currentSource);
        else subtitlesText.gameObject.SetActive(false);
    }

    void OnDestroy(){
        Instance = null;
    }
}
