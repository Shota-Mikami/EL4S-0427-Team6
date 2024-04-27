using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    private int _minute;
    private float _seconds;
    //　タイマー表示用テキスト
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        _minute = Timer.minute;
        _seconds = Timer.seconds;
        timerText.text = _minute.ToString("00") + ":" + ((int)_seconds).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Invoke("ChangeScene", 0.5f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
