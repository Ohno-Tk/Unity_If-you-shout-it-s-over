using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private Text text;
    private int NowCount = 0; // 現在のカウント

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text> ();

        TextIntToString();
    }

    // カウントの初期化
    public void InitializeCount()
    {
        NowCount = 0;

        TextIntToString();
    }

    // カウントアップ
    public void CountUp()
    {
        NowCount++;

        TextIntToString();
    }

    // intを2桁表示にしてstringに変換
    private void TextIntToString()
    {
        text.text = NowCount.ToString("00");
    }

    public void CountReset()
    {
        NowCount = 0;

        TextIntToString();
    }
}
