using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{

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

    public BallController Ball;
    public PlayerController Player;

    public int Score;
    //public Text ScoreLabel; moved to ScoreController
    public Text LivesLabel;
    public Text GetReadyLabel;

    //public uint Score = 0; moved to ScoreController
    public uint Lives = 3;

    uint Briks = 4;
    private bool _gameOver = false;

    public ScoreController currentScore;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Reset();
        currentScore.onScore.AddListener(test);

    }

    public void test(uint score)
    {
        if(score == Briks)
        {
            Victory();
        }
    }

    public void Goal()
    {
        GetReadyLabel.enabled = true;
        //var pos1 = Player.transform.position;
        //pos1.x = 0f;
        //Player.transform.position = pos1; this does not reset the player position anymore

        //Ball.transform.position = Vector3.zero;    //moved to ballcontroller
        //Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //moved to ballcontroller

        //ScoreLabel.text = GamePlay.Instance.Score.ToString(); moved to ScoreController
        LivesLabel.text = GameStateController.Instance.Lives.ToString(); 

        StartCoroutine(StartGame());
    }

    private void Reset()
    {
        //Score = 0; moved to ScoreController
        Lives = 3;
        Briks = 4;

        Goal();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        GetReadyLabel.enabled = false;
        _gameOver = false;
        Ball.Kick();
    }

    private void Update()
    {
#if true //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Lives = 0;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //Score = Briks;    fix this
        }
#endif

        if (_gameOver) return;

        //ScoreLabel.text = GamePlay.Instance.Score.ToString();
        LivesLabel.text = GameStateController.Instance.Lives.ToString();
        /*
        if (Score == Briks)
        {
            SceneManager.LoadScene("Win");
            _gameOver = true;
        }*/   //moved to Victory method
        if (Lives == 0)   //changed to if instead of else if
        {
            SceneManager.LoadScene("Lose");
            _gameOver = true;
        }
    }
    public void checkScore()
    {
        if(ScoreController.Score == Briks)
        {
            Victory();
        }
    }
    public void Victory()
    {
        SceneManager.LoadScene("Win");
        _gameOver = true;
    }
}