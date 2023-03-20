using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public List<AudioClip> buttonSounds; // a list of button sounds
    public AudioSource sfxAudioSource; // Audio source that is used to play all the sfx
    public AudioSource musicAudioSource; // Audio source that is used to play the music
    public List<AudioClip> musicPlaylist; // a list of music clips
    public int playlistIndex = 0; // it is used in music player to keep track of the order in which the songs are played
    // Start is called before the first frame update
    void Start()
    {
        musicAudioSource.clip = musicPlaylist[playlistIndex]; // sets the music clip in the audio source
        musicAudioSource.Play(); // plays the audio source
    }

    // Update is called once per frame
    void Update()
    {
        MusicPlayer();
    }
   
    // It plays the clip from buttonSounds list, it is attached to a button that passes on an int type which later on is used as an index of buttonSounds list.
    public void ButtonSound(int type)
    {
        sfxAudioSource.clip = buttonSounds[type];
        sfxAudioSource.Play();
    }

    // Main button changes the pitch of the auido source for some seconds in order to make the sound of it less repetitive
    public void ButtonRandomPitch()
    {
        sfxAudioSource.pitch = Random.Range( 0.9f, 1.1f);
        StartCoroutine(Wait(0.2f));
    }

    // Volume sliders in main menu
    public void SfxSlider(float x)
    {
        sfxAudioSource.volume = x;
    }

    public void MusicSlider(float x)
    {
        musicAudioSource.volume = x;
    }

    // it resets the pitch after some seconds
    public IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        sfxAudioSource.pitch = 1f;
    }

    public void MusicPlayer()
    {
        if (!musicAudioSource.isPlaying) // ckecks if the music is playing, if not it takes the next song in the list and plays it.
        {
            if(playlistIndex >= musicPlaylist.Capacity) // if the playlist reaches the end of teh list, playlistIndex is set to 0, setting the list on endless loop
            {
                playlistIndex = 0;
            }
            else
            {
                playlistIndex++;
            }
            musicAudioSource.clip = musicPlaylist[playlistIndex];
            musicAudioSource.Play();
        }
    }
}
