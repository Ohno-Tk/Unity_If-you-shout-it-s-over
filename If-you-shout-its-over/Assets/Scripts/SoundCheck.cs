using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{

    [SerializeField]
    private LevelMeter micLevelMeter = null;

     [SerializeField]
    private Counter Count = null;

    // 
    private int VolumeOutValue = 0;
    private bool CountFlag = false;

    public int SetVolumeOutValue { set { VolumeOutValue = value; } }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("音量(%)" + micLevelMeter.VolumePercent);
        //Debug.Log("アウト音量(%)" + VolumeOutValue);

        if(VolumeOutValue < micLevelMeter.VolumePercent && CountFlag == true)
        {
            Count.CountUp();
            CountFlag = false;
        }
        else if(VolumeOutValue > micLevelMeter.VolumePercent)
        {
            CountFlag = true;
        }
    }
}
