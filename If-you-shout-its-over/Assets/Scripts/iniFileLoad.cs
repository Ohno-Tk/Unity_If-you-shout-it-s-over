using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iniFileLoad : MonoBehaviour
{
    public GameObject Camera;

    private string iniFilePath;
    private string iniFileName = "setting.ini";

    // Start is called before the first frame update
    void Start()
    {
        iniFilePath = Application.streamingAssetsPath + "\\";

        // iniファイルの内容を取得
        string string_red = IniFileUtils.read(iniFilePath + iniFileName, "Background", "red");
        string string_green = IniFileUtils.read(iniFilePath + iniFileName, "Background", "green");
        string string_blue = IniFileUtils.read(iniFilePath + iniFileName, "Background", "blue");


        // データ適用
        byte red = (byte)int.Parse(string_red);
        byte green = (byte)int.Parse(string_green);
        byte blue = (byte)int.Parse(string_blue);
        Camera.GetComponent<UnityEngine.Camera>().backgroundColor = new Color32(red, green, blue, 0);
    }
}
