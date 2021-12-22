using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    float timer = 0.0f;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if (timer <= 1f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            score++;
            PlayerPrefs.SetInt("scoreMessage", score);
            scoreText.text = string.Format("Score: " + score);
            timer = 0;
        }
    }
}
