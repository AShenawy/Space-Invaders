using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int enemiesKilled;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI KillsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddKill()
    {
        enemiesKilled++;
        int score = enemiesKilled * 100;
        KillsText.text = "Kills: " + enemiesKilled;
        scoreText.text = "Score: " + score;
    }

    public int CheckScore()
    {
        return enemiesKilled;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
