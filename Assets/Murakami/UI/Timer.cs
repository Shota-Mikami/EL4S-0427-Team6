using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static int minute;
    public static float seconds;
    //�@�O��Update�̎��̕b��
    private float oldSeconds;
    private static bool _isStop;
    //�@�^�C�}�[�\���p�e�L�X�g
    private Text timerText;

    void Start()
    {
        _isStop = false;
        minute = 0;
        seconds = 6f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if(!_isStop)
        {
            seconds -= Time.deltaTime;
            if (minute >= 1 && seconds <= 0f)
            {
                minute--;
                seconds = 59f;
            }
            //�@�l���ς�����������e�L�X�gUI���X�V
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + (seconds).ToString("00");
            }
            oldSeconds = seconds;
        }

        if(seconds < 0f)
        {
            ChangeScene();
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
