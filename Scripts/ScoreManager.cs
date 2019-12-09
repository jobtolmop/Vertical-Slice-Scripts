using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int scoreValue = 0;
    [SerializeField] private Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
       // score.text = "Score: " + scoreValue;
    }
}
