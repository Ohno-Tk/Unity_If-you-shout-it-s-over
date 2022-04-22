using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class MicAudioSource : MonoBehaviour
{
    //サンプリング周波数
    static readonly int SAMPLE_RATE = 48000;

    //この秒数の幅で振幅の平均値を取ったものでdB値を更新
    static readonly float MOVING_AVE_TIME = 0.05f;

    //MOVING_AVE_TIMEに相当するサンプル数
    static readonly int MOVING_AVE_SAMPLE = (int)(SAMPLE_RATE * MOVING_AVE_TIME);

    //マイクのClipをセットする為のAudioSource
    AudioSource micAS = null;

    //現在のdB値
    private float Now_dB;
    public float GetNow_dB { get { return Now_dB; } }

    void Start()
    {
        //AudioSourceコンポーネント取得
        micAS = GetComponent<AudioSource>();

        //フレーム更新開始直後にマイクデバイスをスタートする
        this.MicStart();

        Sound_pressureToDecibel();
    }

    void Update()
    {
        if (micAS.isPlaying)
        {
            Sound_pressureToDecibel();
        }
    }

    // マイクスタート
    private void MicStart()
    {
        //AudioSourceのClipにマイクデバイスをセット
        micAS.clip = Microphone.Start(null, true, 1, SAMPLE_RATE);

        //マイクデバイスの準備ができるまで待つ
        while (!(Microphone.GetPosition("") > 0)) { return; }

        //AudioSouceからの出力を開始
        micAS.Play();
    }

    // デシベル変換
    private void Sound_pressureToDecibel()
    {
        //GetOutputData用のバッファを準備
        float[] data = new float[MOVING_AVE_SAMPLE];

        //AudioSourceから出力されているサンプルを取得
        micAS.GetOutputData(data, 0);

        //バッファ内の平均振幅を取得（絶対値を平均する）
        float aveAmp = data.Average(s => Mathf.Abs(s));

        //振幅をdB（デシベル）に変換
        float dB = 20.0f * Mathf.Log10(aveAmp);

        //現在値（Now_dB）を更新
        Now_dB = dB;

        //Debug.Log("now_dB:"+Now_dB);
        //Debug.Log("現在の音量:"+(Now_dB+80.0f));
    }
}