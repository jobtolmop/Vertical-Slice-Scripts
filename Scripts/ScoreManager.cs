using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int scoreValue = 0;
    [SerializeField] private Text score;
    [SerializeField] private Text highScore;
    [SerializeField] private GameObject pointTxt;

    public GameObject PointTxt { get { return pointTxt; } }

    public int ScoreValue { get { return scoreValue; } set { scoreValue = value; } }

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        score.text = "Score: " + scoreValue;
        highScore.text = "Highscore: 125000";

        if (score == null)
        {
            score = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(3).GetComponent<Text>();
            highScore = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).GetComponent<Text>();
        }
    }
}
