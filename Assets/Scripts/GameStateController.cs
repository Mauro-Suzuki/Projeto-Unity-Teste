using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStateController : MonoBehaviour
{
    public UnityEvent onReset;
    public UnityEvent onStart;

    public ScoreController currentScore;
    public LifeController currentLife;

    public Text GetReadyLabel;

    uint BriksGoal = 4;

    private void Awake()
    {
        GetReadyLabel.enabled = true;
        StartCoroutine(StartGame());

        currentScore.onScore.AddListener(CheckVictory);
        currentLife.onDamageTaken.AddListener(CheckGameOver);
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        GetReadyLabel.enabled = false;
        onStart.Invoke();
    }
    public void CheckVictory(int score)
    {
        if(score == BriksGoal)
        {
            Victory();
        }
    }
    public void CheckGameOver(int life) //check if the player lost all lives and starts lose scene if lost
    {
        if(life <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
        else
        {
            GetReadyLabel.enabled = true;
            StartCoroutine(StartGame());
        }
    }
    public void Victory()
    {
        SceneManager.LoadScene("Win");
    }
}