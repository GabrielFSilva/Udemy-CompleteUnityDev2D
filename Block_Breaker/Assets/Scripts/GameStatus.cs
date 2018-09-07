using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    // Configuration Parameters
    [SerializeField]
    [Range(0.1f, 10f)]
    private float gameSpeed = 1f;
    [SerializeField]
    private int pointsPerBlockDestroyed = 83;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    // State Variables
    [SerializeField]
    private int currentScore = 0;

    // Use this for initialization

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {
        scoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
