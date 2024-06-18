using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int _score = 0;

    public static int _addScore = 10000;

    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = this.GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = _score.ToString("000000");
    }

    public static void ResetScore()
    {
        _score = 0;
    }

    public static void AddScore()
    {
        _score += _addScore;
    }
}
