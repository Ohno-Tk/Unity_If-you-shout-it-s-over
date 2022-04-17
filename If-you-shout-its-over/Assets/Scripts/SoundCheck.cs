using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{

    [SerializeField]
    private MicAudioSource micAS = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(micAS.GetSoundVolume > 60)
        {
            Debug.Log("now_dB:");
        }
    }
}
