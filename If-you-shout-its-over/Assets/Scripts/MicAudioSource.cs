using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class MicAudioSource : MonoBehaviour
{
    const int SAMPLERATE = 48000;// サンプリング周波数

    const float MOVINGAVETIME = 0.05f;// この秒数の幅で振幅の平均値を取ったものでdB値を更新

    const int MOVING_AVE_SAMPLE = (int)(SAMPLERATE * MOVINGAVETIME);// MOVINGAVETIMEに相当するサンプル数

    AudioSource micAS = null;// マイクのClipをセットする為のAudioSource

    private float Now_dB;// 現在のdB値

    public float GetNow_dB { get { return Now_dB; } }

    void Start()
    {
        //AudioSourceコンポーネント取得
        micAS = GetComponent<AudioSource>();

        // マイクデバイスをスタートする
        MicStart(Microphone.devices[0]);
    }

    void Update()
    {
        if (micAS.isPlaying)
        {
            Sound_pressureToDecibel();
        }
    }

    /*
        function: マイクスタート

        param MicDeviceName: マイクデバイス名
    */
    public void MicStart(string MicDeviceName)
    {
        //AudioSourceのClipにマイクデバイスをセット
        //micAS.clip = Microphone.Start(MicDeviceName, true, 1, SAMPLERATE);
        micAS.clip = Microphone.Start(null, true, 1, SAMPLERATE);

        //マイクデバイスの準備ができるまで待つ
        while (!(Microphone.GetPosition(MicDeviceName) > 0)){}
        //while (!(Microphone.GetPosition("") > 0)){}

        //AudioSouceからの出力を開始
        micAS.Play();
    }

    /*
        function: デシベル変換
    */
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
    }
}