using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [Header("Audio Mixer Settings")]
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] string _musicMixerparameter;
    [SerializeField] string _sfxMixerparameter;

    private PlayerRotation _playerRotation;

    private void Start()
    {
        _playerRotation = GameObject.FindObjectOfType<PlayerRotation>();
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat(_musicMixerparameter, volume);
    }

    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat(_sfxMixerparameter, volume);
    }

    public void SetMouseSensivity(float sensivity)
    {
        if (!Application.isPlaying) return;

        _playerRotation.SetSensivity(sensivity);
    }
}
