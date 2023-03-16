using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voice_percent : MonoBehaviour
{
    public GameObject Mic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mic.GetComponent<LevelMeter>().VolumePercent);


        this.GetComponent<Text>().text = Mic.GetComponent<LevelMeter>().VolumePercent.ToString("00");
    }
}
