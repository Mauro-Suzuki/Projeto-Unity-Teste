using UnityEngine;
using UnityEngine.UI;

public class DisplayTopScore : MonoBehaviour
{
    public Text Label;
    
    private void Awake()
    {
       Label.text = "Top Score: " + PlayerPrefs.GetString("HighScore");
    }
}