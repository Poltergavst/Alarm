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

    private void Awake()
    {
        _maxVolume = 1.0f;
        _minVolume = 0f;
        _soundRaisingSpeed = 0.1f;
        _soundFadingSpeed = 0.3f;

        _alarm = GetComponent<AudioSource>();

        _alarm.volume = _minVolume;

        _isActive = false;
    }

    private void Update()
    {
        if (_isActive == true)
        {
            AmplifySound();
        }
        else
        {
            AttenuateSound();
        }
    }

    public void TurnOn()
    {
        _isActive = true;
        _alarm.Play();
    }

    public void TurnOff()
    {
        _isActive = false;
    }

    private void AmplifySound()
    {
        if (_alarm.volume != _maxVolume) 
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _maxVolume, _soundRaisingSpeed * Time.deltaTime);
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
        }
    }
}
