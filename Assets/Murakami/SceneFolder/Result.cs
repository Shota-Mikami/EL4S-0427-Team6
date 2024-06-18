using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    //　タイマー表示用テキスト
    public Text _score;

    // Start is called before the first frame update
    void Start()
    {
        int score = Score._score;
        _score.text = score.ToString();
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
