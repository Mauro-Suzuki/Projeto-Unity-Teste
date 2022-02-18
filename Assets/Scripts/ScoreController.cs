using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
    
[System.Serializable]
public class ScoreEvent : UnityEvent<int>{}
public class ScoreController : MonoBehaviour 
{
    public Text ScoreLabel;

    public static int Score = 0;
    public int highScore;

    public ScoreEvent onScore;


    public void Start()
    {
        var briks = FindObjectsOfType<BrikController>(); //find all the objects with the brikController script
        foreach (var brik in briks)//This will add every brik in an array an also add listener in every one for the onBreak event.
        {
            brik.onBreak.AddListener(AddScore);
        }
        if (onScore == null)
            onScore = new ScoreEvent();

        Score = 0;

        PlayerPrefs.SetString("HighScore", 0.ToString()); //resets highscore to 0 everytime the scene starts
    }

    
    public void AddScore()
    {
        Score++;
        ScoreLabel.text = Score.ToString();
        onScore.Invoke(Score);

        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (Score > highScore)
        {
            highScore = Score;
            if (highScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetString("HighScore", Score.ToString());
            }
        }
    }
}
