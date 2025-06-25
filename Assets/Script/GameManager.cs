using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public GameObject gameOverScreen;

    public GameObject victoryScreen;

    public int AvailiibleLives = 3;

    public int Lives { get; set; }

    public bool isGameStarted {  get; set; }

    private void Start()
    {
        this.Lives = this.AvailiibleLives;
        Screen.SetResolution(540, 900, false);
        Ball.OnBallDeath += OnBallDeath;
        Brick.OnBrickDestruction += OnBrickDestruction;
    }

    private void OnBrickDestruction(Brick obj)
    {
        if (BricksManager.Instance.RemainingBricks.Count <= 0) 
        {
            BallsManager.Instance.ResetBalls();
            GameManager.Instance.isGameStarted = false;
            BricksManager.Instance.LoadNextLevel();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnBallDeath(Ball ball)
    {
        if (BallsManager.Instance.Balls.Count <= 0)
        {
            this.Lives--;

            if(this.Lives <1)
            {
                gameOverScreen.SetActive(true);
            }
            else
            {
                BallsManager.Instance.ResetBalls();
                isGameStarted = false;
                BricksManager.Instance.LoadLevel(BricksManager.Instance.CurrentLevel);
            }
            
        }
        
    }

    private void OnDisable()
    {
        Ball.OnBallDeath -= OnBallDeath;
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }
}
