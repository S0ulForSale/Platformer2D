using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mainMixer;

    [SerializeField] Slider musicSlider;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        if (volume == 0)
        {
            mainMixer.SetFloat("music", -80f);
        }
        else
        {
            mainMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        }
    }
}