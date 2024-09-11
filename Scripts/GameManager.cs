using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject game;
    public GameObject player;
    public GameObject menu;
    public GameObject intro;
    public GameObject mort;
    public GameObject campaign;

    public GameObject canvasShop;
    public GameObject canvasMenu;
    public GameObject cameraMenu;
    public GameObject shop1;
    public GameObject shop2;
    public GameObject pausedMenu;
    

    public AudioSource audioMenu;
    public AudioSource audioGame;
    public AudioSource audioIntro;
    public AudioSource audioDead;

    public PlayerMovement playerScript;
    public ResetScene resetSceneScript;

    public bool inGame = false;
    public bool gameIsPaused = false;

    public void Start()
    {
        game.SetActive(true);
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            player.SetActive(false); // D�sactiver le joueur
            game.SetActive(false); // D�sactive Game
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            playerScript.allCoin = PlayerPrefs.GetInt("Coins");
        }

        if (PlayerPrefs.HasKey("NiveauAm�lioration1"))
        {
            resetSceneScript.nivAmelioration1 = PlayerPrefs.GetInt("NiveauAm�lioration1");
        }

        if (PlayerPrefs.HasKey("NiveauAm�lioration2"))
        {
            resetSceneScript.nivAmelioration2 = PlayerPrefs.GetInt("NiveauAm�lioration2");
        }

        if (PlayerPrefs.HasKey("NiveauAm�lioration3"))
        {
            resetSceneScript.nivAmelioration3 = PlayerPrefs.GetInt("NiveauAm�lioration3");
        }

        if (PlayerPrefs.HasKey("NiveauAm�lioration4"))
        {
            resetSceneScript.nivAmelioration4 = PlayerPrefs.GetInt("NiveauAm�lioration4");
        }

        if (PlayerPrefs.HasKey("NiveauAm�lioration5"))
        {
            resetSceneScript.nivAmelioration5 = PlayerPrefs.GetInt("NiveauAm�lioration5");
        }

        if (PlayerPrefs.HasKey("NiveauAm�lioration6"))
        {
            resetSceneScript.nivAmelioration6 = PlayerPrefs.GetInt("NiveauAm�lioration6");
        }

        inGame = false;
        campaign.SetActive(false);
        game.SetActive(false);
        menu.SetActive(true);
        intro.SetActive(false);
        mort.SetActive(false);
        canvasShop.SetActive(true);
        canvasMenu.SetActive(true);
        cameraMenu.SetActive(true);
        shop1.SetActive(false);
        shop2.SetActive(false);
        audioMenu.Play();
    }

    public void Update()
    {
        playerScript.textPieceMenu.text = playerScript.allCoin.ToString();
        playerScript.textPieceMenu2.text = playerScript.allCoin.ToString();

        if(inGame == true && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Resume()
    {
        audioGame.Play();
        pausedMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Paused()
    {
        audioGame.Pause();
        pausedMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void PlayZombie()
    {
        inGame = true;
        player.SetActive(true);
        campaign.SetActive(false);
        game.SetActive(true);
        menu.SetActive(false);
        intro.SetActive(false);
        mort.SetActive(false);
        audioMenu.Stop();
        audioGame.Play();
        playerScript.kill = 0;
    }

    public void PlayCampaign()
    {
        inGame = true;
        campaign.SetActive(true);
        game.SetActive(false);
        menu.SetActive(false);
        intro.SetActive(false);
        mort.SetActive(false);
    }

    public void BackMenu()
    {
        inGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
