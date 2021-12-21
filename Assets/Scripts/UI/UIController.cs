using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public SFXManager sfxManager;
    public GameObject backGroundMusic;
    

    public int totalDefeatedEnemy = 0;
    public float timePassed = 0f;
    public float timeStored = 0f;
    public float timeLimit = 0f;
    public int level = 1;
    public float survivedSec = 0f;
    public bool isGameScreenOn = false;


    [SerializeField] GameObject startGameCanvas;

    [SerializeField] GameObject gameScreen;

    [SerializeField] GameObject gameTextCanvas;//
    [SerializeField] Text timeLimitText;
    [SerializeField] Text tipsText;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text defeatedEnemiesTextInGameOverCanvas;
    [SerializeField] Text survivedTextInGameOverCanvas;
    [SerializeField] Text levelTextInGameOverCanvas;


    [SerializeField] GameObject enemyGroup;
    [SerializeField] GameObject enemy2Group;
    [SerializeField] GameObject enemy3Group;


    public void Start()
    {
        //IsGameScreenOn();//
        //LevelUp();//


        /* When Level up, randomly switch BGM
        backGroundMusic = GameObject.Find("GameBackgroundMusic");
        backGroundMusic.GetComponent<BackGroundMusicManager>().BGMSelecter();
        */

    }

    public void Update()
    {
        IsGameScreenOn();//

        SetForNextLevel();//

        Timer();//

        TimeLimitCountDown();//

        GameOver();


        //Test fpr Game Over Screen//
        //if (Input.GetKeyDown(KeyCode.T))//

    }


    public void IsGameScreenOn()
    {
        if (gameScreen.activeSelf)
        {
            isGameScreenOn = true;
        }
        else
        {
            isGameScreenOn = false;
        }
    }

    public void LevelUp() 
    {
        level++;
    }

    public void CountUpEnemyDefeated()
    {
        //killCount++;
        totalDefeatedEnemy++;// = killCount;
    }

    public void Timer()
    {
        if (isGameScreenOn == true) 
        {
            //timePassed = Time.time;
            timePassed += Time.deltaTime;
            //Debug.Log(timePassed);//
        }
    }

    public void TimeLimitCountDown() 
    {
        if ((isGameScreenOn == true) && (level >= 2)) 
        {
            timeLimit -= Time.deltaTime;
            Debug.Log(timeLimit);//

            timeLimitText.text = timeLimit.ToString("f2");
        }
    }

    /*
    public void StartCountDown()
    {
        if (isStartingNextLevel == true)
        {
            timeLimit -= (timePassed - timeLimit);
        }
    }
   
    */

    public void SetForNextLevel()
    {
        if ((totalDefeatedEnemy >= (27 * level)) && (timeLimit >= 0))
        {
            // Set seconds for contdown which is rounded up previous cleartime
            //timeLimit = Mathf.Ceil(timePassed);//


            timeLimit = timePassed - timeStored;
            timeStored += timePassed - timeStored;

            //TimeLimitCountDown();//

            // Level+1
            LevelUp();

            TipsToPlay();//

            //isStartingNextLevel = true;//

            //timeLimit -= (timePassed - timeLimit);//

            //GameSceneCanvas();//

            //timePassed = 0 ;//

            ResetEnemyGroups();//

        }
    }

    public void TipsToPlay()
    {
        string[] tipsToPlayText = new string[]
        {
            "SPACE KEY to SHOOT.. \n RIGHT / LEFT ARROW KEYS to MOVE..",
            "count down starts..",
            "V(-.o)V",
            "beat yourself..",
            ":)",
            "..wait..take it easy..",
            "~(^._.)",
            "wanna live a life like..",
            "=^. .^="
        };

        if (level  <= tipsToPlayText.Length) 
        {
            tipsText.text = tipsToPlayText[level - 1];
        }
    }

    public void GameOver()
    {
        if (timeLimit < 0)
        {
            //isPlayAgain = true;//

            survivedSec = timePassed;//

            ResetEnemyGroups();//

            ShowGameOverCanvas();//

            InitializeRecord();//
        }
    }

    public void ShowGameOverCanvas() 
    {
        gameOverCanvas.SetActive(true);
        startGameCanvas.SetActive(false);
        gameScreen.SetActive(false);

        defeatedEnemiesTextInGameOverCanvas.text = totalDefeatedEnemy.ToString();
        survivedTextInGameOverCanvas.text = survivedSec.ToString("f2");
        levelTextInGameOverCanvas.text = level.ToString();

        //InitializeRecord();//

        //ResetEnemyGroups();//

        /*if (timeLimit < 0)
        {
            
        }*/
    }

    public void ToTitle()
    {
        sfxManager.PlaySFX("MouseClick");

        ShowStartGameCanvas();
    }

    public void InitializeRecord() 
    {
        //killCount = 0;
        totalDefeatedEnemy = 0;
        timePassed = 0f;
        timeStored = 0f;
        timeLimit = 0f;
        level = 1;
        //isStartingNextLevel = false;//

        timeLimitText.text = "";//
        tipsText.text = "";//
        //defeatedEnemiesTextInGameOverCanvas.text = null;
        //LevelTextInGameOverCanvas.text = null;

        //ResetEnemyGroups();//
    }

    public void ShowStartGameCanvas()
    {
        startGameCanvas.SetActive(true);
        gameScreen.SetActive(false);
        gameOverCanvas.SetActive(false);

        //InitializeRecord();//
    }

    public void Play()
    {
        //InitializeRecord();//
        sfxManager.PlaySFX("MouseClick");

        gameScreen.SetActive(true);
        startGameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    public void ResetEnemyGroups() 
    {
        // Get EnemyGroup setActive
        enemyGroup = GameObject.Find("EnemyGroup");
        GameObject[] enemies = enemyGroup.GetComponent<EnemyController>().enemies;
        GameObject[] enemiesArray = enemies;//

        for (int i = 0; i < enemiesArray.Length; i++)
        {
            //enemiesArray[i].SetActive(false);//

            if (!enemiesArray[i].activeSelf)
            {
                enemiesArray[i].SetActive(true);
            }
        }

        // Get Enemy2Group setActive
        enemy2Group = GameObject.Find("Enemy2Group");
        GameObject[] enemies2Array = enemy2Group.GetComponent<EnemyController>().enemies;

        for (int j = 0; j < enemies2Array.Length; j++)
        {
            //enemies2Array[i].SetActive(false);//

            if (!enemies2Array[j].activeSelf) 
            {
                enemies2Array[j].SetActive(true);
            }
        }

        // Get Enemy3Group setActive//
        enemy3Group = GameObject.Find("Enemy3Group");
        GameObject[] enemies3Array = enemy3Group.GetComponent<EnemyController>().enemies;

        for (int k = 0; k < enemies3Array.Length; k++)
        {
            //enemies3Array[i].SetActive(false);//

            if (!enemies3Array[k].activeSelf) 
            {
                enemies3Array[k].SetActive(true);
            }
        }
    }
}
