using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public TMP_Text text;
    [TextArea]
    public string ruText;
    [TextArea]
    public string enText;

    public void Awake(){
        if (PlayerPrefs.GetString("language") == "ru")
            text.text = ruText;
        else
            text.text = enText;
    }
}
