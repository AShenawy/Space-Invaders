using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SpriteRenderer playerImage;

    public TextMeshProUGUI reason;

    // Start is called before the first frame update
    void Start()
    {
        //display playerpref 
        reason.text = string.Format(PlayerPrefs.GetString("loseMessage"));
    }

    // Update is called once per frame
    void Update()
    {
        //if player pressed Enter load 0 scene
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }

        // cool rotation of plane
        transform.Translate(Vector3.down * 3f * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, -45 * Time.deltaTime);
    }
}
