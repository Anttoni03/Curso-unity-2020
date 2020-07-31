using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public enum GameState
    {
        titleMenu,
        inGame,
        timeOut
    }
    public GameState gameState;
    
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject timeOutMenu;
    public List<GameObject> targetPrefabs;
    public float spawnRate = 1.5f;
    public Slider timeSlider;
    public float maxTimeGame;

    private float score;
    private const float TIME_TO_QUIT = 0.05f;

    //===============================================================================================================

    // Set inGame state, start to spawning, reset the score and start the time left
    public void StartGame()
    {
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScoreText(0);
        titleScreen.SetActive(false);
        timeSlider.gameObject.SetActive(true);
        StartCoroutine(StartTimeBack());
    }

    //===============================================================================================================

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (gameState==GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    //===============================================================================================================

    // Decreases the time slider and end the game with it
    public IEnumerator StartTimeBack()
    {
        timeSlider.maxValue = maxTimeGame;
        timeSlider.value = maxTimeGame;
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(TIME_TO_QUIT);
            timeSlider.value -= TIME_TO_QUIT;
            if (timeSlider.value == 0)
            {
                gameState=GameState.timeOut;
                GameOver();
            }
        }
    }

    //===============================================================================================================

    // Update the score with value from target clicked
    public void UpdateScoreText(float scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;
    }

    //===============================================================================================================

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        timeOutMenu.gameObject.SetActive(true);
        gameState = GameState.timeOut;
    }

    //===============================================================================================================

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}