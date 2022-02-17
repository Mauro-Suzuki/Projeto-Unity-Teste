using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTopScore : MonoBehaviour
{
    public Text Label;
    
    private void Awake()
    {
        //var n = GamePlay.Instance.Score; fix this
        //Label.text += n.ToString();
       Label.text = "Top Score: " + PlayerPrefs.GetString("HighScore");
    }


}