using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{

    [SerializeField]
    private LevelMeter micLevelMeter = null;

    [SerializeField]
    private Counter Count = null;

    private int VolumeOutValue = 0;// アウトの値(デシベル換算)

    private bool CountFlag = false;// 連続カウント防止用フラグ

    public int SetVolumeOutValue { set { VolumeOutValue = value; } }

    void Start()
    {
        VolumeOutValue = 70;
    }

    // Update is called once per frame
    void Update()
    {
        // アウト時
        if(VolumeOutValue < micLevelMeter.VolumePercent && CountFlag == true)
        {
            Count.CountUp();
            CountFlag = false;
        }
        // それ以外
        else if(VolumeOutValue-3 > micLevelMeter.VolumePercent)
        {
            CountFlag = true;
        }
    }
}
