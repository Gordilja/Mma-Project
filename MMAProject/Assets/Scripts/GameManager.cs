using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] BackgroundMove bgMove;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] AudioManager audioManager;
    [SerializeField] PlayerControls posReset;
    [SerializeField] PlayerCollisions playerCol;

    [SerializeField] GameObject debugMenu;
    [SerializeField] GameObject bgPicture;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject pauseBtn;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelClearPanel;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject scorePanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject shopPausePanel;
    [SerializeField] GameObject levelHolder;
    [SerializeField] GameObject debMenuBtn;

    [SerializeField] Text scoreTxt;
    [SerializeField] Text dolphinscoreTxt;
    [SerializeField] Text levelTxt;
    int dolphinCount;
    int score;
    int i;

    private void Awake()
    {
        bgPicture.SetActive(true);
        audioManager.bdMusicMenuPlay();
        startPanel.SetActive(true);
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameClearPanel.SetActive(false);
        scorePanel.SetActive(false);
        pauseBtn.SetActive(false);
        score = 0;
    }

    private void Update()
    {
        levelTxt.text = "LVL:" + (i+1);
        scoreTxt.text = score.ToString();
        dolphinscoreTxt.text = dolphinCount.ToString();
    }

    public void SkinsStart() 
    {
        Time.timeScale = 0;
        scorePanel.SetActive(false);
        shopPanel.SetActive(true);
        bgPicture.SetActive(true);
        startPanel.SetActive(false);
    }
    public void SkinsPause()
    {
        Time.timeScale = 0;
        scorePanel.SetActive(false);
        bgPicture.SetActive(true);
        shopPausePanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void BacktoMainmenu() 
    {
        Time.timeScale = 0;
        shopPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void backtoPauseMenu()
    {
        Time.timeScale = 0;
        shopPausePanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void playGame() 
    {
        audioManager.bdPlay();
        audioManager.bdMusicMenuMute();
        scorePanel.SetActive(true);
        bgPicture.SetActive(false);
        bgMove.movingBG = true;
        bgMove.resetBGPos = false;
        playerScript.controls = true;
        Time.timeScale = 1;
        startPanel.SetActive(false);
        pauseBtn.SetActive(true);
        debMenuBtn.SetActive(true);
    }

    public void pauseGame() 
    {
        Time.timeScale = 0;
        scorePanel.SetActive(false);
        bgPicture.SetActive(true);
        audioManager.bdMute();
        audioManager.bdMusicMenuUnmute();
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        debMenuBtn.SetActive(false);
        debugMenu.SetActive(false);
    }

    public void resumeGame() 
    {
        Time.timeScale = 1;
        debMenuBtn.SetActive(true);
        scorePanel.SetActive(true);
        bgPicture.SetActive(false);
        audioManager.bdUnmute();
        audioManager.bdMusicMenuMute();
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
    }

    public void gameOver() 
    {
        bgMove.movingBG = false;
        debMenuBtn.SetActive(false);
        debugMenu.SetActive(false);
        scorePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        playerScript.controls = false;
    }

    public void gameCleared() 
    {
        bgMove.movingBG = false;
        debMenuBtn.SetActive(false);
        debugMenu.SetActive(false);
        pauseBtn.SetActive(false);
        gameClearPanel.SetActive(true);
        playerScript.controls = false;
    }

    public void quitGame() 
    {
        Application.Quit();
    }

    public void levelClear() 
    {
        bgMove.movingBG = false;
        debMenuBtn.SetActive(false);
        debugMenu.SetActive(false);
        pauseBtn.SetActive(false);
        levelClearPanel.SetActive(true);
        playerScript.controls = false;
    }

    public void scoreUp()
    {
        scoreTxt.text = score.ToString();
        score += 5;
    }

    public void dolphinUp()
    {
        scoreTxt.text = score.ToString();
        score += 15;
        dolphinCount++;
    }

    #region Nextlvl
    IEnumerator boolResetBG()
    {
        bgMove.resetBGPos = true;
        yield return new WaitForSeconds(0.2f);
        bgMove.resetBGPos = false;
        bgMove.movingBG = true;
    }

    IEnumerator changelevel()
    { 
        StartCoroutine(boolResetBG());
        levelHolder.transform.GetChild(i).gameObject.SetActive(false);
        levelClearPanel.SetActive(false);
        i++;
        yield return new WaitForSeconds(0.2f);
        levelHolder.transform.GetChild(i).gameObject.SetActive(true);
        posReset.ResetPosition();
        playerScript.controls = true;   

    }

    public void next()
    {
        StartCoroutine(changelevel());
        debMenuBtn.SetActive(true);
        debugMenu.SetActive(false);
        pauseBtn.SetActive(true);
    }
    #endregion
    public void retry()
    {
        StartCoroutine(retrySpawn());
        debMenuBtn.SetActive(true);
        debugMenu.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    IEnumerator retrySpawn()
    {
        yield return new WaitForSeconds(0.1f);
        startPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain() 
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
  
    public void restartG()
    {
        posReset.ResetPosition();
        bgMove.movingBG = true;
        scorePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        playerScript.controls = true;
        bgMove.resetBGPos = true;
        playerCol.DeadReset();
        debMenuBtn.SetActive(true);
        debugMenu.SetActive(false);
    }

    public void DebugMenuOn() 
    {
        debMenuBtn.SetActive(false);
        debugMenu.SetActive(true);
        bgMove.movingBG = false;
        pauseBtn.SetActive(false);
        playerScript.controls = false;
    }

    public void DebugMenuOff()
    {
        debMenuBtn.SetActive(true);
        debugMenu.SetActive(false);
        pauseBtn.SetActive(true);
        bgMove.movingBG = true;
        playerScript.controls = true;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Dolphins", dolphinCount);
    }
}
