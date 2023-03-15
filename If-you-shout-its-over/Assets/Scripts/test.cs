using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string val = IniFileUtils.read("D:\\programming\\Unity_ShoutSupport\\If-you-shout-its-over\\Assets\\test.ini", "drivers", "wave", "", System.Text.Encoding.GetEncoding("UTF-8"));
        string val = IniFileUtils.read("D:\\programming\\Unity_ShoutSupport\\If-you-shout-its-over\\Assets\\test.ini", "drivers", "wave");

        Debug.Log(val);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
