using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeRemaining = 10.5f;


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "time" + Mathf.Round(timeRemaining).ToString();

        }
        else
        {
            timeRemaining = 0;

            timerText.text = "time:No Bonus";

        }
    }
}
//https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/