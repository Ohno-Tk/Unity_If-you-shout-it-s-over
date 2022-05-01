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

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        Settting();
    }

    // 各種設定
    public void Settting()
    {
        Graduate();

        SliderPercentage.TextChange((int)slider.value);

        soundCheck.SetVolumeOutValue = (int)slider.value;
    }

    //5刻みでスライダーを表示する。
    private void Graduate()
    {
        float sliderValue = slider.value;

        sliderValue = Mathf.Round(sliderValue / 5) * 5;

        slider.value = sliderValue;
    }
}
