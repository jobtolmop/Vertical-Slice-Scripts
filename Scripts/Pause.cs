using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void Resume()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pauze()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        ScoreManager.instance.ScoreValue = 0;
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
