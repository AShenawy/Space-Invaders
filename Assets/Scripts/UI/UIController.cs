using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *(Yoshio)
 *This script was created to set rules of the game and control UIs.
 *There is no condition to win in this game. 
 *However, player needs to defeat all enemies within seconds to cont down which is set based on player's clear time at previous level.
 *In order to play longer, player needs to play more effectively than before.
 */

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject startGameCanvas;

    [SerializeField] GameObject gameScreen;
    [SerializeField] Text timeLimitText;
    [SerializeField] Text tipsText;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text defeatedEnemiesTextInGameOverCanvas;
    [SerializeField] Text survivedTextInGameOverCanvas;
    [SerializeField] Text levelTextInGameOverCanvas;

    [SerializeField] GameObject enemyGroup;
    [SerializeField] GameObject enemy2Group;
    [SerializeField] GameObject enemy3Group;

    public SFXManager sfxManager;
    public GameObject backGroundMusic;
    
    public int totalDefeatedEnemy = 0;
    public float timePassed = 0f;
    public float timeStored = 0f;
    public float timeLimit = 0f;
    public int level = 1;
    public float survivedSec = 0f;
    public bool isGameScreenOn = false;

    string[] tipsToPlayText = new string[]
        {
            "SPACE KEY to SHOOT..\nRIGHT / LEFT ARROW KEYS to MOVE..",
            "count down starts..",
            "V(-.o)V",
            "beat yourself..",
            ":)",
            "..wait..take it easy..",
            "~(^._.)",
            "wanna live a life like..",
            "=^. .^=",
            "=^. .^=\n=^. .^="
        };

    public void Update()
    {
        IsGameScreenOnChecker();/*(Yoshio)Cause of small alart. Need to inspect.*/

        SetForNextLevel();/*(Yoshio)Cause of small alart. Need to inspect.*/

        CountUpTimer();

        CountDownTimeLimit();

        SetGameOver();
    }

    /*
     * (Yoshio)This function sets condition to shift to new level / set seconds for count down / what to do when shifting to next level stage.
     * As a unique feature of this game, the seconds for count down is determined player's clear time at the last stage.
     * It means, real enemy of this game is player him/herself, not aliens.
     * The order of these functions is very important to show right results.
     */
    public void SetForNextLevel()
    {
        // 27 is the number of enemies. 
        if ((totalDefeatedEnemy >= (27 * level)) && (timeLimit >= 0))
        {
            timeLimit = timePassed - timeStored;
            timeStored += timePassed - timeStored;

            LevelUp();

            ShowTipsToPlay();

            ResetEnemyGroups();

            RandomizeBGM();/*(Yoshio)Cause of small alart. Need to inspect.*/
        }
    }

    /*
     * (Yoshio)This function sets game over condition and what to do when game over.
     * The order of these 3 indivisual functions is very important to show right results.
     */
    public void SetGameOver()
    {
        if (timeLimit < 0)
        {
            survivedSec = timePassed;

            ResetEnemyGroups();

            ShowGameOverCanvas();

            InitializeRecord();
        }
    }

    /*
     * (Yoshio)When pressed "To Title" button on GameOverCanvas, paly sound effects and set only StartGameCanvas actived.
     */
    public void MoveToTitleCanvas()
    {
        sfxManager.PlaySFX("MouseClick");

        ShowStartGameCanvas();
    }


    /*
     * (Yoshio)
     * This function is indirectly set for just initializing the record of count down seconds uopn game over.
     * If this function deactivated, it can cheat to continue to play without count down timer, but there's no option to finish ongoing stage..
     */
    public void IsGameScreenOnChecker()
    {
        if (gameScreen.activeSelf)/*(Yoshio)Cause of small alart. Need to inspect.*/
        {
            isGameScreenOn = true;
        }
        else
        {
            isGameScreenOn = false;
        }
    }

    /*
     * (Yoshio)This function starts count up all enemies defeated until game over.
     */
    public void CountUpEnemyDefeated()
    {
        totalDefeatedEnemy++;
    }

    /*
     * (Yoshio)This function increases level until game over.
     */
    public void LevelUp()
    {
        level++;
    }

    /*
 *(Yoshio) 
 *When shifting scene due to game over or continue to the next level stage, this function can reactivate enemies destoroyed. 
 *Instead of "Destroy(gameObject);", used ".SetActive(true).
 */
    public void ResetEnemyGroups()
    {
        /*
         *(Yoshio)To get EnemyGroup reactivated.
         */
        enemyGroup = GameObject.Find("EnemyGroup");
        GameObject[] enemies = enemyGroup.GetComponent<EnemyController>().enemies; /*(Yoshio) Cause of small alart. Need to inspect.*/
        GameObject[] enemiesArray = enemies;

        for (int i = 0; i < enemiesArray.Length; i++)
        {
            if (!enemiesArray[i].activeSelf)
            {
                enemiesArray[i].SetActive(true);
            }
        }

        /*
         *(Yoshio)To get Enemy2Group reactivated.
         */
        enemy2Group = GameObject.Find("Enemy2Group");
        GameObject[] enemies2Array = enemy2Group.GetComponent<EnemyController>().enemies;

        for (int j = 0; j < enemies2Array.Length; j++)
        {
            if (!enemies2Array[j].activeSelf)
            {
                enemies2Array[j].SetActive(true);
            }
        }

        /*
         *(Yoshio)To get Enemy3Group reactivated.
         */
        enemy3Group = GameObject.Find("Enemy3Group");
        GameObject[] enemies3Array = enemy3Group.GetComponent<EnemyController>().enemies;

        for (int k = 0; k < enemies3Array.Length; k++)
        {
            if (!enemies3Array[k].activeSelf)
            {
                enemies3Array[k].SetActive(true);
            }
        }
    }

    /*
     * (Yoshio)This function can randomly change BGM during game play.
     * To custormize BGM sounds, change elements in Array of "backGroundMusics".
     */
    public void RandomizeBGM()
    {
        backGroundMusic = GameObject.Find("GameBackgroundMusic");
        backGroundMusic.GetComponent<BackGroundMusicManager>().BGMSelecter();/*(Yoshio)Cause of small alart. Need to inspect.*/
    }

    /*
     * (Yoshio)This function can show some texts in the center of game screen during game play, which is about how to play this game at first.
     * However, the more proceeding levels, the text is getting a bit funny.
     * When it shows ascii art of 2 cats (reached Level 10), there is no more texts to show.
     * To custormize text elements, change texts elements in Array of "tipsToPlayText".
     */
    public void ShowTipsToPlay()
    {
        if (level <= tipsToPlayText.Length)
        {
            tipsText.text = tipsToPlayText[level - 1];
        }
    }

    /*
     * (Yoshio)This function starts count up seconds after starting game stage.
     */
    public void CountUpTimer()
    {
        if (isGameScreenOn == true)
        {
            timePassed += Time.deltaTime;
        }
    }

    /*
     * (Yoshio)This function starts count down after activating level 2.
     * It also shows the seconds left on the top of the game screen.
     */
    public void CountDownTimeLimit()
    {
        if ((isGameScreenOn == true) && (level >= 2))
        {
            timeLimit -= Time.deltaTime;
            //Debug.Log(timeLimit);

            timeLimitText.text = timeLimit.ToString("f2");
        }
    }

    /*
     *(Yoshio)To set only StartGameCanvas activated.
     */
    public void ShowStartGameCanvas()
    {
        startGameCanvas.SetActive(true);
        gameScreen.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    /*
     *(Yoshio)When pressed "Play" button on StartGameCanvas, paly sound effects and set only GameScreen actived.
     */
    public void MoveToGameScreen()
    {
        sfxManager.PlaySFX("MouseClick");

        gameScreen.SetActive(true);
        startGameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    /*
     *(Yoshio) When meeting game over condition, set only GameOverCanvas activated and show some results of game play on GameOverCanvas.
     */
    public void ShowGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        startGameCanvas.SetActive(false);
        gameScreen.SetActive(false);

        defeatedEnemiesTextInGameOverCanvas.text = totalDefeatedEnemy.ToString();
        survivedTextInGameOverCanvas.text = survivedSec.ToString("f2");
        levelTextInGameOverCanvas.text = level.ToString();
    }

    /*
     *(Yoshio)To reset default values for core variables and text element before starting new game, not before just continue to next level stage.
     */
    public void InitializeRecord()
    {
        totalDefeatedEnemy = 0;
        timePassed = 0f;
        timeStored = 0f;
        timeLimit = 0f;
        level = 1;
        survivedSec = 0f;
        isGameScreenOn = false;

        timeLimitText.text = "";
        tipsText.text = tipsToPlayText[level - 1];
    }

}
