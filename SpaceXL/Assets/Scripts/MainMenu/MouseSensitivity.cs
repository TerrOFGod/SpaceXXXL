using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public Slider MouseX;
    [SerializeField] public Slider MouseY;

    [Header("Keys")]
    [SerializeField] private string MouseXKey;
    [SerializeField] private string MouseYKey;

    [Header("Tags")]
    [SerializeField] private string MouseXSliderTag;
    [SerializeField] private string MouseYSliderTag;

    [Header("Parameters")]
    [SerializeField] private float XSensitivity;
    [SerializeField] private float YSensitivity;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(MouseYKey))
        {
            XSensitivity = PlayerPrefs.GetFloat(MouseYKey);

            GameObject slider1 = GameObject.FindWithTag(MouseYSliderTag);
            if (slider1 != null)
            {
                MouseY.value = YSensitivity;
            }
        }
        else
        {
            YSensitivity = 160f;
            PlayerPrefs.SetFloat(MouseYKey, YSensitivity);
        }

        if (PlayerPrefs.HasKey(MouseXKey))
        {
            XSensitivity = PlayerPrefs.GetFloat(MouseXKey);

            GameObject slider1 = GameObject.FindWithTag(MouseXSliderTag);
            if (slider1 != null)
            {
                MouseX.value = XSensitivity;
            }
        }
        else
        {
            XSensitivity = 160f;
            PlayerPrefs.SetFloat(MouseXKey, XSensitivity);
        }
    }

    private void LateUpdate()
    {
        XSensitivity = MouseX.value;
        YSensitivity = MouseY.value;
        PlayerPrefs.SetFloat(MouseXKey, XSensitivity);
        PlayerPrefs.SetFloat(MouseYKey, YSensitivity);
    }
}
