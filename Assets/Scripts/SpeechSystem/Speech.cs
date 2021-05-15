using UnityEngine;

[CreateAssetMenu(menuName = "Speech Item")]
public class Speech : ScriptableObject
{
    public string SubtitlesEng, SubtitlesRus;
    public float Duration;
    public AudioClip Sound;
    public Speech Next;
}
