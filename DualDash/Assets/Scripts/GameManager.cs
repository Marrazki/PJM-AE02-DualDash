
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private IScoreService scoreService;
    public TMP_Text scoreText;
    public float score;
    public static GameManager Instance;
    public GameObject gameOverPanel;

    public bool IsGameOver { get; private set; }

    void Awake()
    {
        scoreService = new PlayerPrefsScoreService();

        score = 0;
        UpdateScoreText();

        Instance = this;
        Time.timeScale = 1f;
        IsGameOver = false;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    void Update()
    {
        if (IsGameOver) return;

        score += Time.deltaTime;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "" + Mathf.FloorToInt(score);
    }

    public void EndGame()
    {
        if (IsGameOver) return;

        IsGameOver = true;

        int finalScore = Mathf.FloorToInt(score);
        scoreService.SaveBestScore(finalScore);

        Debug.Log("Puntuación final: " + finalScore);
        Debug.Log("Mejor puntuación: " + scoreService.GetBestScore());

        Time.timeScale = 0f;

        Debug.Log("GAME OVER");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
