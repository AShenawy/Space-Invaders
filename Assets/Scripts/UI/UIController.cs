using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public SFXManager sfxManager;
    public GameObject backGroundMusic;

    //public int killCount = 0;//
    public int totalDefeatedEnemy = 0;
    public float timePassed = 0f;
    public float timeStored = 0f;
    public float timeLimit = 0f;
    public int level = 1;
    //public bool isStartingNextLevel = false;//
    //public bool isPlayAgain = false;//
    public bool isGameScreenOn = false;


    [SerializeField] GameObject startGameCanvas;

    [SerializeField] GameObject gameScreen;

    [SerializeField] GameObject gameTextCanvas;
    [SerializeField] Text timeLimitText;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] Text defeatedEnemiesTextInGameOverCanvas;
    [SerializeField] Text LevelTextInGameOverCanvas;

    
    [SerializeField] GameObject enemyGroup;
    [SerializeField] GameObject enemy2Group;
    [SerializeField] GameObject enemy3Group;

    //[SerializeField] GameObject enemies;//
    //[SerializeField] Text levelText;//
    //[SerializeField] Text defeatedEnemiesText;//



    public void Start()
    {
        //LevelUp();

        
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

        //Test fpr Game Over Screen//
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            //isPlayAgain = true;//

            ResetEnemyGroups();//RSI<<<<-----how to reset Timelimit result in game screen??

            ShowGameOverCanvas();//

            InitializeRecord();//
        }
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

            timeLimitText.text = "TimeLimit: " + timeLimit.ToString("f2");
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

            //isStartingNextLevel = true;//

            //timeLimit -= (timePassed - timeLimit);//

            //GameSceneCanvas();//

            //timePassed = 0 ;//

            ResetEnemyGroups();//

        }
    }

    
    public void GameSceneCanvas()
    {
        gameTextCanvas.SetActive(true);
        /* Not use but just for check
        levelText.text = "Level : " + level.ToString();
        defeatedEnemiesText.text = "Enemies defeated : " + totalDefeatedEnemy.ToString();
        */

        
        if (level < 2)
        {
            timeLimitText.text = "" ;//
        }
        else 
        {
            if (startGameCanvas.activeSelf)
            {
                timeLimitText.text = "" ;//
            }
            else 
            {
                timeLimitText.text = "TimeLimit : " + timeLimit.ToString();//<<<<<---------------------How to Manage this??
            }
        }


        /*
        if ((level >= 2) && (!startGameCanvas.activeSelf)) //
        {
            timeLimitText.text = "TimeLimit : " + timeLimit.ToString();//
        }
        */

        /*
        if (isStartingNextLevel == true) 
        {
            
        }*/
    }


    public void ShowGameOverCanvas() 
    {
        gameOverCanvas.SetActive(true);
        startGameCanvas.SetActive(false);
        gameScreen.SetActive(false);

        defeatedEnemiesTextInGameOverCanvas.text = totalDefeatedEnemy.ToString();
        LevelTextInGameOverCanvas.text = level.ToString();

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

        //timeLimitText.text = null;
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
