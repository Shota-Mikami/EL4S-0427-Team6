using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static int minute;
    public static float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    private static bool _isStop;
    //　タイマー表示用テキスト
    private Text timerText;

    void Start()
    {
        _isStop = false;
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if(!_isStop)
        {
            seconds += Time.deltaTime;
            if (seconds >= 60f)
            {
                minute++;
                seconds = seconds - 60;
            }
            //　値が変わった時だけテキストUIを更新
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSeconds = seconds;
        }


        //if (Input.GetKey(KeyCode.Space))
        //    Invoke("ChangeScene", 0.5f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Result");
    }

    public static void Clear()
    {
        _isStop = true;
    }
}
