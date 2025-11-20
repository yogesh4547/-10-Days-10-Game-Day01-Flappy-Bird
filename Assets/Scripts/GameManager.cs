using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Game Objects")]
    [SerializeField] private PipeSpawner pipeSpawner;

    private int score = 0;
    private int highScore = 0;
    private bool gameStarted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        Time.timeScale = 0f;

        if (startPanel != null)
            startPanel.SetActive(true);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateScoreUI();
    }

    void Update()
    {
        if (!gameStarted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;

        if (startPanel != null)
            startPanel.SetActive(false);

        if (pipeSpawner != null)
            pipeSpawner.StartSpawning();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (highScoreText != null)
                highScoreText.text = "High Score: " + highScore;
        }

        if (pipeSpawner != null)
            pipeSpawner.StopSpawning();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
