using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicDeviceSelect : MonoBehaviour
{
    private Dropdown micDropdown;

    

    private void Awake()
    {
        // Dropdownコンポーネント取得
        micDropdown = GetComponent<Dropdown>();

        // マイクデバイスをドロップダウンに追加
        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            Debug.Log(i + " : " + Microphone.devices[i]);
            micDropdown.options.Add(new Dropdown.OptionData { text = Microphone.devices[i] });
        }

        micDropdown.RefreshShownValue();
    }

    public void SetMic()
    {

    }
}
