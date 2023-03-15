using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iniFileLoad : MonoBehaviour
{
    private string iniFilePath;
    private string iniFileName = "setting.ini";

    // Start is called before the first frame update
    void Start()
    {
        iniFilePath = Application.streamingAssetsPath + "\\";

        //string val = IniFileUtils.read("D:\\programming\\Unity_ShoutSupport\\If-you-shout-its-over\\Assets\\test.ini", "drivers", "wave", "", System.Text.Encoding.GetEncoding("UTF-8"));
        string val = IniFileUtils.read(iniFilePath + iniFileName, "Background", "green");

        Debug.Log(val);
        Debug.Log(Directory.GetCurrentDirectory());
    }
}
