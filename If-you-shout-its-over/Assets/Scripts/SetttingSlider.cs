using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetttingSlider : MonoBehaviour
{
    [SerializeField]
    private SoundCheck soundCheck;

    [SerializeField]
    private SliderPercentage SliderPercentage;

    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        // 各種設定
        Settting();
    }

    /*
        function: 各種設定
    */
    public void Settting()
    {
        // 5刻みでスライダーを表示する。
        Graduate();

        // スライダーの値をテキスト変換
        SliderPercentage.TextChange((int)slider.value);

        // スライダーの値をアウト判定の値に代入
        soundCheck.SetVolumeOutValue = (int)slider.value;
    }

    /*
        function: 5刻みでスライダーを表示する。
    */
    private void Graduate()
    {
        float sliderValue = slider.value;

        // 5で割って整数に丸めて5倍してやり、5分ごとの値とする
        sliderValue = Mathf.Round(sliderValue / 5) * 5;

        slider.value = sliderValue;
    }
}
