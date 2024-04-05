using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private List<AudioClip>    _evilLaughClips;
    [SerializeField] private List<AudioClip>    _musicClips;
    [SerializeField] private List<AudioClip>    _eatingSoulClipsSFX;
    [SerializeField] private AudioClip          _eatingSoundSFX;
    [SerializeField] private AudioClip          _goodEndingClipSFX;
    [SerializeField] private AudioClip          _badEndingClipSFX;
    [SerializeField] private AudioClip          _poolOfSoulsSFX;
    [SerializeField] private AudioMixer         _mixer;
    [SerializeField] private AudioSource        _audioSourceMusic;
    [SerializeField] private AudioSource        _audioSourceSFX;
    [SerializeField] private AudioSource        _bgAudioSourceSFX;
    [SerializeField] private AudioSource        _savedSoulAudioSource;
    
    private void    Awake()
    {
        Instance = this;
    }
    private void    Start()
    {
        PlayMusicBg(0);
        PlayGamePlaySFX();
    }
    public void     PlayEvilLaugh()
    {

    }

    /// <summary>
    /// 0 = game play  -  1 Ending
    /// </summary>
    /// <param name="_index"></param>
    public void     PlayMusicBg(int _index)
    {
        _audioSourceMusic.clip = _musicClips[_index];
        _audioSourceMusic.Play();
    }
    public void     PlayGamePlaySFX()
    {
        _bgAudioSourceSFX.clip = _poolOfSoulsSFX;
        _bgAudioSourceSFX.Play();
    }
    public void     PlayEndingSound(bool _good)
    {

    }
    public void     PlayEatingSoul()
    {
        if(!_savedSoulAudioSource.isPlaying)
            _savedSoulAudioSource.Play();
    }
    public void     PlaySkullEatingSoul()
    {
        if (_audioSourceSFX.isPlaying)
            return;

        _audioSourceSFX.clip = _eatingSoulClipsSFX[Random.Range(0, _eatingSoulClipsSFX.Count)];
        _audioSourceSFX.Play();
    }
}
