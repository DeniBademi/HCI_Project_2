using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Music")] 
    [SerializeField] private AudioClip[] mainThemes;

    private AudioSource _audioSource;
    private ObjectPooler _pooler;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _pooler = GetComponent<ObjectPooler>();
        PlayMusic();
    }

    /// <summary>
    /// Plays our background music
    /// </summary>
    private void PlayMusic()
    {
        if (_audioSource == null)
        {
            return;
        }

        int randomTheme = Random.Range(0, mainThemes.Length);
        
        _audioSource.clip = mainThemes[randomTheme];
        _audioSource.Play();
    }

    /// <summary>
    /// Plays a sound
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        // Get AudioSource GameObject
        GameObject newAudioSourceGO = _pooler.GetObjectFromPool();
        newAudioSourceGO.SetActive(true);

        // Get AudioSource from object
        AudioSource source = newAudioSourceGO.GetComponent<AudioSource>();
        
        // Setup AudioSource
        source.clip = clip;
        source.volume = 0f;
        source.Play();

        StartCoroutine(IEReturnToPool(newAudioSourceGO, clip.length + 0.1f));
    }

    /// <summary>
    /// Return on sound object back to the pool
    /// </summary>
    /// <param name="objectToReturn"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator IEReturnToPool(GameObject objectToReturn, float time)
    {
        yield return new WaitForSeconds(time);
        objectToReturn.SetActive(false);
    }
}
