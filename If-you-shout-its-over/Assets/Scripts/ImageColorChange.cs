using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColorChange : MonoBehaviour
{
    public void Show()
    {
        GetComponent<Image>().color = new Color32 (125, 125, 125, 125);
    }

    public void Hide()
    {
        GetComponent<Image>().color = new Color32 (255, 255, 255, 255);
    }
}
