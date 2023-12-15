using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    [SerializeField] TMP_InputField nameInput;

    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
        nameInput.text = PlayerPrefs.GetString("name", "Name");
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log($"Name: {name}");
        PlayerPrefs.SetString("name", name);
    }

    public void OnSpeedValue(float speed)
    {
        Debug.Log($"Speed: {speed}");
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
