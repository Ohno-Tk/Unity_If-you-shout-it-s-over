using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class LevelMeter : MonoBehaviour
{
    Image levelMeterImage = null;// 更新する対象のlevelMeter(uGUI Image)

    [SerializeField]
    private float dB_Min= -80.0f;// このdBでlevelMeter表示の下限に到達する

    [SerializeField]
    private float dB_Max = -0.0f;// このdBでlevelMeter表示の上限に到達する

    [SerializeField]
    private MicAudioSource micAS = null;// dBを取得する対象のmicAudioSource

    private float volume = 0.0f;

    public float VolumePercent { get { return volume * 100.0f; } }

    void Start()
    {
        //更新する対象のImageを取得
        levelMeterImage = GetComponent<Image>();

        volume = dBToFillAmountValue(micAS.GetNow_dB);
    }

    void Update()
    {
        //dB値からlevelMeterImage用のfillAountの値に変換
        volume = dBToFillAmountValue(micAS.GetNow_dB);

        Debug.Log(micAS.GetNow_dB);

        //fillAmount値更新
        this.levelMeterImage.fillAmount = volume;
    }

    /*
        function: dB_Minとdb_Maxに基づいてdBをfillAmount値に変換

        param dB: dB値
        return: fillAmount値
    */
    float dBToFillAmountValue(float dB)
    {
        //入力されたdBをdB_MaxとdBMin値で切り捨て
        float modified_dB = dB;

        if (modified_dB > dB_Max) { modified_dB = dB_Max; }
        else if (modified_dB < dB_Min) { modified_dB = dB_Min; }

        //fillAmount値に変換(dB_Min=0.0f, dB_Max=1.0f)
        float fillAountValue = 1.0f + (modified_dB / (dB_Max - dB_Min));

        return fillAountValue;
    }
}