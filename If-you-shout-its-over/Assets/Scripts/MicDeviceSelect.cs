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

        // マイクデバイスをドロップダウンに追加
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            Debug.Log(i + " : " + Microphone.devices[i]);
            micDropdown.options.Add(new Dropdown.OptionData { text = Microphone.devices[i] });
            //Debug.Log(" 型: " + Microphone.devices[i].GetType());
        }

        // ドロップダウンの一番最初を表示
        micDropdown.RefreshShownValue();

        Debug.Log(" index: " + micDropdown.value);

        micAS.MicStart(Microphone.devices[micDropdown.value]);
    }

    public void SetMic()
    {
        Debug.Log(" マイク名: " + Microphone.devices[micDropdown.value]);

        micAS.MicStart(Microphone.devices[micDropdown.value]);
    }
}
