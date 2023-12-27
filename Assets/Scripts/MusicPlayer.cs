using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public Dropdown songDropdown;
    public Text currentSongText;
    [SerializeField]
    private List<AudioClip> playlist = new List<AudioClip>(); // Serialize this field to edit in inspector
    
    private int currentTrackIndex = 0;
    void Start()
    {
        PopulateDropdownWithSongs();
        UpdateSongDisplay();
    }

    // Populate the dropdown with song names
    private void PopulateDropdownWithSongs()
    {
        songDropdown.ClearOptions();
        List<string> songNames = new List<string>();
        foreach (var song in playlist)
        {
            songNames.Add(song.name);
        }
        songDropdown.AddOptions(songNames);
    }

    // Update the text to show the current song
    private void UpdateSongDisplay()
    {
        currentSongText.text = playlist[currentTrackIndex].name;
    }

    // Play the selected song
    public void PlaySong()
    {
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();
        UpdateSongDisplay();
    }

    // Go to the next song
    public void SkipSong()
    {
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
        UpdateSongSelection();
        PlaySong();
    }

    // Go to the previous song
    // Go to the previous song
    public void PreviousSong()
    {
        if (currentTrackIndex == 0)
        {
            currentTrackIndex = playlist.Count - 1;
        }
        else
        {
            currentTrackIndex--;
        }
        UpdateSongSelection();
        PlaySong();
    }

    // This will be called when selecting a song from the dropdown
    public void SelectSongFromDropdown(int index)
    {
        currentTrackIndex = index;
        PlaySong();
    }

    // Update dropdown selection and song display text
    private void UpdateSongSelection()
    {
        songDropdown.value = currentTrackIndex;
        songDropdown.RefreshShownValue();
        UpdateSongDisplay();
    }
}
