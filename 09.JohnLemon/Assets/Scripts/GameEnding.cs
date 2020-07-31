using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeTime = 1f;
    public float displayImageTime = 1f;
    public GameObject player;
    private bool isPlayerAtExit, isPlayerCaught;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    private float timer;
    public AudioSource exitAudio, caughtAudio;
    private bool hasAudioPlayed;

    //==============================================================================================================

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
    
    //==============================================================================================================

    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    //==============================================================================================================

    /// <summary>
    /// Lanza la imagen de fin de parida y cierra el juego
    /// </summary>
    /// <param name="imageCanvasGroup">Imagen de fin de partida a mostrar</param>
    private void EndLevel(CanvasGroup imageCanvasGroup, bool restart, AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = Mathf.Clamp(timer / fadeTime, 0, 1);
        if (timer > fadeTime + displayImageTime)
        {
            if (restart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    //==============================================================================================================

    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
}
