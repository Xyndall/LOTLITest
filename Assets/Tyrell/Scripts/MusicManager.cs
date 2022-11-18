using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{



    #region MyRegion
    //[SerializeField] private AudioClip[] aMenuMusic;
    //[SerializeField] private AudioClip[] aIdleMusic;
    //[SerializeField] private AudioClip[] aBattleMusic;
    //public int State;

    //void Start()
    //{
    //    aSource = GetComponent<AudioSource>();

    //    switch (State)
    //    {
    //        case 2:
    //            BattleMusic();
    //            break;

    //        case 1:
    //            IdleMusic();
    //            break;

    //        case 0:
    //            MenuMusic();
    //            break;

    //    }

    //}


    //void BattleMusic()
    //{
    //    int newClip = Random.Range(0, aBattleMusic.Length);
    //}

    //void IdleMusic()
    //{
    //    int newClip = Random.Range(0, aIdleMusic.Length);
    //}

    //void MenuMusic()
    //{
    //    int newClip = Random.Range(0, aMenuMusic.Length);
    //    PlayMusic(aBattleMusic[newClip]);
    //}


    //void PlayMusic(AudioClip music)
    //{
    //    aSource.clip = music;
    //    aSource.Play();
    //} 
    #endregion

    public List<AudioClip> BattleMusicClips = new List<AudioClip>();
    public List<AudioClip> MenuMusicClips = new List<AudioClip>();
    public List<AudioClip> IdleMusicClips = new List<AudioClip>();

    public MusicQueue musicQueue;

    // 2D music player.
    public static AudioSource music;

    // Audio currently playing.
    AudioClip currentTrack;

    // Length of the current track; used to know when to play next
    private float length;

    private Coroutine musicLoop;

    private AudioSource musicSource;


    public int State;

    void Start()
    {
        switch (State)
        {
            case 2:
                musicQueue = new MusicQueue(BattleMusicClips);
                break;

            case 1:
                musicQueue = new MusicQueue(MenuMusicClips);
                break;

            case 0:
                musicQueue = new MusicQueue(IdleMusicClips);
                break;

            default:
                musicQueue = new MusicQueue(IdleMusicClips);
                break;
            
                

        }

        musicSource = GetComponent<AudioSource>();

        StartCoroutine(StartSongs());
    }

    IEnumerator StartSongs()
    {
        yield return new WaitForSeconds(1);
        StartMusic();
    }

    public void PlayMusicClip(AudioClip music)
    {
        musicSource.Stop();
        musicSource.clip = music;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (musicLoop != null)
            StopCoroutine(musicLoop);

        music.Stop();
    }

    public void StartMusic()
    {
        musicLoop = StartCoroutine(musicQueue.LoopMusic(this, 0, PlayMusicClip));
    }

}

public class MusicQueue
{
    List<AudioClip> clips;

    public MusicQueue(List<AudioClip> clips)
    {
        this.clips = clips;
    }

    public IEnumerator LoopMusic(MonoBehaviour player, float delay, System.Action<AudioClip> playFunction)
    {
        while (true)
        {
            yield return player.StartCoroutine(Run(RandomizeList(clips), delay, playFunction));
        }
    }

    // Runs all music clips, then repeats if desired
    public IEnumerator Run(List<AudioClip> tracks,
        float delay, System.Action<AudioClip> playFunction)
    {
        // Run all clips
        foreach (AudioClip clip in tracks)
        {
            // play
            playFunction(clip);

            // Wait until the clip is done, and delay between clips is over
            yield return new WaitForSeconds(clip.length + delay);
        }
    }

    public List<AudioClip> RandomizeList(List<AudioClip> list)
    {
        List<AudioClip> copy = new List<AudioClip>(list);

        int n = copy.Count;

        // what we do here is grab any random track,
        // then set the last track in the copy to be that track,
        // then we remove the last track from the list of tracks we need to change.

        // basically, we move from largest index to smallest,
        // setting the current index to a random clip from the smallest index
        // and up to the largest index that has not been set
        while (n > 1)
        {
            n--;

            // exclusive int range, add one since we remove one earlier
            int k = Random.Range(0, n + 1);

            // store temporary value
            AudioClip value = copy[k];

            // swap without overwrite
            copy[k] = copy[n];
            copy[n] = value;
        }

        return copy;
    }
}

