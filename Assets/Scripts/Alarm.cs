using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private readonly float _maxVolume = 1f;
    private readonly float _minVolume = 0f;
    private readonly float _speedVolumeChange = 0.2f;
    private AudioSource _audioSource;
    private Coroutine _currentCoroutine;
    private bool _isSoundPlay;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Work(bool isPlayerInHouse)
    {
        StopCoroutineIfExist();

        switch (isPlayerInHouse)
        {
            case true:
                _currentCoroutine = StartCoroutine(ManageSound(_maxVolume));
                break;

            case false:
                _currentCoroutine = StartCoroutine(ManageSound(_minVolume));
                break;
        }
    }

    private void StopCoroutineIfExist()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }

    private void PlaySound()
    {
        if (_isSoundPlay == false)
        {
            _audioSource.Play();
            _isSoundPlay = true;
        }
    }

    private void StopSound()
    {
        if (_audioSource.volume <= _minVolume)
        {
            _audioSource.Stop();
            _isSoundPlay = false;
        }
    }

    private IEnumerator ManageSound(float target)
    {
        PlaySound();

        while (_audioSource.volume != target)
        {
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, target, _speedVolumeChange * Time.deltaTime);
            yield return null;
        }

        StopSound();
    }
}