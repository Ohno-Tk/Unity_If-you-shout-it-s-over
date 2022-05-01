using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text text; // uGUIのText
    private int NowCount = 0; // 現在のカウント

    void Start()
    {
        text = this.GetComponent<Text> ();

        TextIntToString();
    }

    /*
        function: カウントアップ
    */
    public void CountUp()
    {
        NowCount++;

        TextIntToString();
    }

    /*
        function: カウントの初期化
    */
    public void CountReset()
    {
        NowCount = 0;

        TextIntToString();
    }

    /*
        function: intをN桁表示にしてstringに変換
    */
    private void TextIntToString()
    {
        // N桁表示
        text.text = NowCount.ToString("00");

        //Debug.Log("現在のカウント" + NowCount + "回");
    }
}
