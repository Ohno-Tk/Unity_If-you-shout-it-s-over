using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicDeviceSelect : MonoBehaviour
{
    private Dropdown micDropdown;

    [SerializeField]
    private MicAudioSource micAS = null;

    private void Start()
    {
        // Dropdownコンポーネント取得
        micDropdown = GetComponent<Dropdown>();

        // マイクデバイスを取得してドロップダウンに追加
        GetMicDevice();

        // マイクスタート
        micAS.MicStart(Microphone.devices[micDropdown.value]);
    }

    /*
        function: マイクデバイスを取得してドロップダウンに追加
    */
    private void GetMicDevice()
    {
        // ドロップダウンに追加
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            Debug.Log(i + " : " + Microphone.devices[i]);
            micDropdown.options.Add(new Dropdown.OptionData { text = Microphone.devices[i] });
        }

        // ドロップダウンの一番最初を表示
        micDropdown.RefreshShownValue();
    }
}
