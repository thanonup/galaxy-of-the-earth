using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public Text ScoreEnd;

    private float Score_;

    void Update()
    {
        if (GameManager.instance.isLose == false)
        {
            Score_ += Time.deltaTime * 1;
            Score.text = ((int)Score_).ToString("SCORE : 0000");
            ScoreEnd_(Score_);
        }
    }
    public void ScoreEnd_(float scoreend)
    {
        ScoreEnd.text = ((int)scoreend).ToString("SCORE : 0000");
    }
}
