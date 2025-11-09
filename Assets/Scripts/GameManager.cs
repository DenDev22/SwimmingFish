using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject menuButton;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);
        menuButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        PipesMove[] pipesMoves = FindObjectsByType<PipesMove>(FindObjectsSortMode.None);

        for (int i = 0; i < pipesMoves.Length; i++)
        {
            Destroy(pipesMoves[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncraseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        menuButton.SetActive(true);

        Pause();
    }

    public void Menu()
    {
        menuButton.SetActive(false);
    }
}
