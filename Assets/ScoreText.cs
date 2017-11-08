using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreText : MonoBehaviour
{
    //スコア初期設定
    private int score = 0;
    
    // Use this for initialization
    void Start()
    {
        //初期スコア(0点)を表示
        GetComponent<Text>().text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //スコア加算用メソッド
    public void AddPoint(int point)
    {
        score = score + point;
        GetComponent<Text>().text = "Score: " + score.ToString();
    }
}