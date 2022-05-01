using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercentage : MonoBehaviour
{
    /*
        function: スライダーの値をテキスト変換

        param slidervalue: スライダー値

    */
    public void TextChange(int slidervalue)
    {
        GetComponent<Text>().text = slidervalue + "%";
    }
}
