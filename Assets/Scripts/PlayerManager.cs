using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool levelStarted;
    public GameObject startPanel;
    public static bool gameOver;
    public GameObject overPanel;
    public static int stars;
    public TextMeshProUGUI starText;
    public static int score;
    public TextMeshProUGUI highScoreText;
    public float forwardSpeed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = levelStarted = false;
        Time.timeScale = 1;
        stars = 0;
        score = 0;
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        starText.text = PlayerPrefs.GetInt("TotalStars", 0) + stars.ToString();
        Touchscreen ts = Touchscreen.current;

        if (ts != null && ts.primaryTouch.press.isPressed && !levelStarted) 
        {
            levelStarted = true;
            startPanel.SetActive(false);
        }

        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;

        if (gameOver)
        {
            Time.timeScale = 0;
            overPanel.SetActive(true);
            PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars", 0) + stars);
            if (stars > PlayerPrefs.GetInt("HighScore", 0))
            {
                highScoreText.text = "NEW HIGHSCORE " + stars.ToString();
                PlayerPrefs.SetInt("HighScore", stars);
            }
            this.enabled = false;
        }
    }
}
