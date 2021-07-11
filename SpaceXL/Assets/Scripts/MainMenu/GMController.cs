using UnityEngine;
using UnityEngine.UI;

public class GMController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] public Slider sliderGame;

    [Header("Keys")]
    [SerializeField] private string gameVolumeKey;

    [Header("Tags")]
    [SerializeField] private string gameSliderTag;

    [Header("Parameters")]
    [SerializeField] private float gameVolume;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(gameVolumeKey))
        {
            gameVolume = PlayerPrefs.GetFloat(gameVolumeKey);

            GameObject slider1 = GameObject.FindWithTag(gameSliderTag);
            if (slider1 != null)
            {
                sliderGame.value = gameVolume;
            }
        }
        else
        {
            gameVolume = 0.5f;
            PlayerPrefs.SetFloat(gameVolumeKey, gameVolume);
        }
    }

    private void LateUpdate()
    {
        gameVolume = sliderGame.value;

        PlayerPrefs.SetFloat(gameVolumeKey, gameVolume);
    }
}
