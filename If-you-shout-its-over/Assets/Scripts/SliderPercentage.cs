using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercentage : MonoBehaviour
{
    public void TextChange(int value)
    {
        GetComponent<Text>().text = value + "%";
    }
}
