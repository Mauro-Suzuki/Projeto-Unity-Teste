using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public BallController Ball;
    public PlayerController Player;   
    public ScoreController currentScore;
    public LifeController currentLife;

    public Text GetReadyLabel;

    uint BriksGoal = 4;

    private bool _gameOver = false;

    private void Awake()
    {
            Reset();
        currentScore.onScore.AddListener(CheckVictory);
        currentLife.onDamageTaken.AddListener(CheckLife);

    }
    private void Update()
    {
        if (_gameOver) return;

    }
    public void CheckVictory(uint score)
    {
        if(score == BriksGoal)
        {
            Victory();
        }
    }
    public void CheckLife(int life) //check if the player lost all lives and starts lose scene if lost
    {
        if(life <= 0)
        {
            SceneManager.LoadScene("Lose");
            _gameOver = true;
        }
    }

    public void Reset()
    {
        GetReadyLabel.enabled = true;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        GetReadyLabel.enabled = false;
        _gameOver = false;
        Ball.Kick();
    }
    public void Victory()
    {
        SceneManager.LoadScene("Win");
        _gameOver = true;
    }
}





//unused/removed code
/*
private static GameStateController _instance;
public static GameStateController Instance
{
    get
    {
        if (_instance == null)
        {
            var go = new GameObject("GameStateController");
            _instance = go.AddComponent<GameStateController>();
        }

        return _instance;
    }
}
*/

/*
if (_instance == null)
{
    _instance = this;
    DontDestroyOnLoad(gameObject);
}
*/
//public Text ScoreLabel; moved to ScoreController
//public Text LivesLabel;


//public uint Score = 0; moved to ScoreController
//public uint Lives = 3;


//var pos1 = Player.transform.position;
//pos1.x = 0f;
//Player.transform.position = pos1; this does not reset the player position anymore

//Ball.transform.position = Vector3.zero;    //moved to ballcontroller
//Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //moved to ballcontroller

//ScoreLabel.text = GamePlay.Instance.Score.ToString(); moved to ScoreController
//LivesLabel.text = GameStateController.Instance.Lives.ToString(); moved to LifeController


//Score = 0; moved to ScoreController
//Lives = 3; moved to LifeController


/*#if true //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Lives = 0; removed
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //Score = Briks;    fix this
        }*/


//ScoreLabel.text = GamePlay.Instance.Score.ToString(); removed and moved to ScoreController
//LivesLabel.text = GameStateController.Instance.Lives.ToString(); moved to LifeController

/*
if (Score == Briks)
{
    SceneManager.LoadScene("Win");
    _gameOver = true;
}   //moved to Victory method

if (Lives == 0)   //changed to if instead of else if
{
    SceneManager.LoadScene("Lose");
    _gameOver = true;                 moved to checkLife
}*/