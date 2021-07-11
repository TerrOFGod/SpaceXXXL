using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public AudioSource audioMenu;
    [SerializeField] public Slider sliderMenu;

    [Header("Keys")]
    [SerializeField] private string menuVolumeKey;

    [Header("Tags")]
    [SerializeField] private string menuSliderTag;

    [Header("Parameters")]
    [SerializeField] private float menuVolume;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(menuVolumeKey))
        {
            menuVolume = PlayerPrefs.GetFloat(menuVolumeKey);
            audioMenu.volume = menuVolume;

            GameObject slider1 = GameObject.FindWithTag(menuSliderTag);
            if(slider1 != null)
            {
                sliderMenu.value = menuVolume;
            }
        }
        else
        {
            menuVolume = 0.5f;
            PlayerPrefs.SetFloat(menuVolumeKey, menuVolume);
            audioMenu.volume = menuVolume;
        }
    }

    private void LateUpdate()
    {
        menuVolume = sliderMenu.value;

        if(audioMenu.volume != menuVolume)
        {
            PlayerPrefs.SetFloat(menuVolumeKey, menuVolume);
        }

        audioMenu.volume = menuVolume;
    }
}
