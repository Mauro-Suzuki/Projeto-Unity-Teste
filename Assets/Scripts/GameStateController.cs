using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStateController : MonoBehaviour
{
    public UnityEvent onReset;
    public UnityEvent onStart;

    public Score currentScore;
    public Life currentLife;

    public Text GetReadyLabel;

    uint BriksGoal = 4;

    private void Awake()
    {
        GetReadyLabel.enabled = true;
        StartCoroutine(StartGame());

        currentScore.onScore.AddListener(CheckVictory); //subscribed to onScore event
        currentLife.onDamageTaken.AddListener(CheckGameOver); //subscribed to onDamageTaken event
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        GetReadyLabel.enabled = false;
        onStart.Invoke();
    }
    public void CheckVictory(int score)  //receives int from event to check if the player won
    {
        if(score == BriksGoal)
        {
            Victory();
        }
    }
    public void CheckGameOver(int life) //receives int and check if the player lost all lives and load lose scene if lost
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