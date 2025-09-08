using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestKeyboard : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject keyboard; 

    private void Awake()
    {
        text.text = "-";
        var buttons = keyboard.GetComponentsInChildren<Button>();

        foreach (var key in buttons)
        {
                var keyboardText = key.GetComponentInChildren<TextMeshProUGUI>();
                var value = keyboardText;

                key.onClick.AddListener(() => { ClickKeyboard(keyboardText.text); });
        }

    }

    private float timer = 0f;
    private float interval = 0.5f;
    private bool isActive = true;

    public void ClickKeyboard(string value)
    {
        text.text += value;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            isActive = !isActive;
            text.enabled = isActive;
            timer = 0f;
        }
    }
}
