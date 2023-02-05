using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    [SerializeField] TextMeshProUGUI playerWhoWon;
    [SerializeField] GameObject gameOverPanel;
    public List<Player> players;

    public bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGameDelayed());
        player1ScoreText.text = "P1 - ";
        player2ScoreText.text = "P2 - ";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator StartGameDelayed()
    {
        yield return new WaitForSeconds(2);
        gameStarted = true;
    }

    public void GameOver()
    {
        if(players[0].score > players[1].score)
        {
            playerWhoWon.text = players[0].tag + " " + playerWhoWon.text;
            playerWhoWon.color = players[0].playerColor;
        }
        else if(players[0].score < players[1].score)
        {
            playerWhoWon.text = players[1].tag + " " + playerWhoWon.text;
            playerWhoWon.color = players[1].playerColor;
        }
        else
        {
            playerWhoWon.text = "";
            playerWhoWon.text = "Draw";
            playerWhoWon.color = Color.yellow;
        }
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
