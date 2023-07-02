using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;
    }

    public void OnSliderChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
