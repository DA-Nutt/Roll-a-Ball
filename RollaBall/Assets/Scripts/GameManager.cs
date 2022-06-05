using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject winText;
    public GameObject loseText;

    public bool gameHasEnded;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            loseText.SetActive(true);
            player.SetActive(false);
            Invoke("ResetGame", 4f);
        }
        
    }

    public void WinGame()
    {
        winText.SetActive(true);
        enemy.SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
