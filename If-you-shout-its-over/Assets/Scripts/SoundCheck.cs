using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{

    [SerializeField]
    private LevelMeter micLevelMeter = null;

     [SerializeField]
    private Counter Count = null;

    private bool CountFlag = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("音量(%)" + micLevelMeter.VolumePercent);

        if(micLevelMeter.VolumePercent > 60 && CountFlag == true)
        {
            Count.CountUp();
            CountFlag = false;
        }
        else if(micLevelMeter.VolumePercent < 50)
        {
            CountFlag = true;
        }
    }
}
