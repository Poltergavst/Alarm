using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmPlayer : MonoBehaviour
{
    private float _maxVolume;
    private float _minVolume;
    private float _soundRaisingSpeed;
    private float _soundFadingSpeed;

    private bool _isActive;

    private AudioSource _alarm;
    private WaitForEndOfFrame _wait;

    private void Awake()
    {
        _maxVolume = 1.0f;
        _minVolume = 0f;
        _soundRaisingSpeed = 0.1f;
        _soundFadingSpeed = 0.3f;

        _alarm = GetComponent<AudioSource>();
        _alarm.volume = _minVolume;

        _wait = new WaitForEndOfFrame();

        _isActive = false;
    }

    public void TurnOn()
    {
        _isActive = true;
        _alarm.Play();

        StartCoroutine(ChangeSound());
    }

    public void TurnOff()
    {
        _isActive = false;

        StartCoroutine(ChangeSound());
    }

    private void AmplifySound()
    {
        if (_alarm.volume != _maxVolume) 
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, _soundRaisingSpeed * Time.deltaTime);
        }
        else
        {
            StopCoroutine(ChangeSound());
        }    
    }

    private void AttenuateSound()
    {
        if (_alarm.volume != _minVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _minVolume, _soundFadingSpeed * Time.deltaTime);
        }
        else
        {
            _alarm.Stop();

            StopCoroutine(ChangeSound());
        }
    }

    private IEnumerator ChangeSound()
    {
        while (_alarm.isPlaying == true)
        {
            if (_isActive == true)
            {
                AmplifySound();
            }
            else
            {
                AttenuateSound();
            }

            yield return _wait;
        }
    }
}
