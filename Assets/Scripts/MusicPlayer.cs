using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> playlist = new List<AudioClip>();
    public Button playPauseButton;
    public Button skipButton;
    public Button previousButton;
    public Text songTitleText;
    public Slider volumeSlider; // Reference to the volume slider

    private int currentTrackIndex = 0;
    private bool isPlaying = false;

    void Start()
    {
        if (playlist.Count > 0)
        {
            PlayTrack(currentTrackIndex);
        }

        playPauseButton.onClick.AddListener(TogglePlayPause);
        skipButton.onClick.AddListener(SkipTrack);
        previousButton.onClick.AddListener(PreviousTrack);

        // Initialize the volume slider
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    void PlayTrack(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= playlist.Count) return;

        audioSource.clip = playlist[trackIndex];
        audioSource.Play();
        songTitleText.text = playlist[trackIndex].name;
        isPlaying = true;
    }

    void TogglePlayPause()
    {
        if (isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
        isPlaying = !isPlaying;
    }

    void SkipTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
        PlayTrack(currentTrackIndex);
    }

    void PreviousTrack()
    {
        currentTrackIndex--;
        if (currentTrackIndex < 0)
        {
            currentTrackIndex = playlist.Count - 1;
        }
        PlayTrack(currentTrackIndex);
    }

    // Method to adjust the volume
    void AdjustVolume(float newVolume)
    {
        audioSource.volume = newVolume;
    }
}
