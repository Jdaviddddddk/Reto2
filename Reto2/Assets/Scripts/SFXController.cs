using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SFXController : MonoBehaviour
{
    public Slider soundSlider; // Reference to the slider for sound effects volume
    public Toggle muteToggle; // Reference to the toggle for muting all sounds
    public List<AudioSource> soundEffects; // List of all sound effect AudioSources
    private bool isMuted = false;

    private void Start()
    {
        // Initialize slider with saved volume setting (if available)
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);

        // Set initial volume for all sound effect AudioSources
        foreach (AudioSource soundEffect in soundEffects)
        {
            soundEffect.volume = soundSlider.value;
        }

        // Add listeners to slider and toggle value changes
        soundSlider.onValueChanged.AddListener(UpdateSoundVolume);
        muteToggle.onValueChanged.AddListener(ToggleMute);
    }

    private void UpdateSoundVolume(float volume)
    {
        // Update volume for all sound effect AudioSources and save setting
        foreach (AudioSource soundEffect in soundEffects)
        {
            soundEffect.volume = volume;
        }
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    private void ToggleMute(bool mute)
    {
        isMuted = mute;
        foreach (AudioSource soundEffect in soundEffects)
        {
            soundEffect.mute = mute;
        }
    }
}



