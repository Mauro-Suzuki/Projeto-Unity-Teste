using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
    
[System.Serializable]
public class ScoreEvent : UnityEvent<int>{}
public class Score : MonoBehaviour 
{
    public Text ScoreLabel;
    public static int currentScore = 0;
    public int highScore;
    public ScoreEvent onScore;
    public void Start()
    {
        var briks = FindObjectsOfType<Brik>(); //find all the objects with the brikController script
        foreach (var brik in briks)//This will add every brik in an array an also add listener in every one for the onBreak event.
        {
            brik.onBreak.AddListener(AddScore);
        }
        if (onScore == null)
            onScore = new ScoreEvent();

        currentScore = 0;

        PlayerPrefs.SetString("HighScore", 0.ToString()); //resets highscore to 0 everytime the scene starts, can be removed if needed
    }

    
    public void AddScore()
    {
        currentScore++;
        ScoreLabel.text = currentScore.ToString();

        onScore.Invoke(currentScore);
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            if (highScore > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetString("HighScore", currentScore.ToString());
            }
        }
    }
}
