using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField]
    private Slider SliderObject = null;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = (int)(SliderObject.value) + "%";
    }

    public void TextChange()
    {
        GetComponent<Text>().text = (int)(SliderObject.value) + "%";
    }
}
