using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmPlayer : MonoBehaviour
{
    private float _maxVolume;
    private float _minVolume;
    private float _soundChangingSpeed;

    private AudioSource _alarm;
    private Coroutine _soundChanger;

    private void Awake()
    {
        _maxVolume = 1.0f;
        _minVolume = 0f;
        _soundChangingSpeed = 0.3f;

        _alarm = GetComponent<AudioSource>();
        _alarm.volume = _minVolume;
    }

    public void TurnOn()
    {
        _alarm.Play();

        if (_soundChanger != null) 
        {
            StopCoroutine(_soundChanger);
        }

        _soundChanger = StartCoroutine(ChangeSound(_maxVolume));
    }

    public void TurnOff()
    {
        if (_soundChanger != null)
        {
            StopCoroutine(_soundChanger);
        }

        _soundChanger = StartCoroutine(ChangeSound(_minVolume));
    }

    private IEnumerator ChangeSound(float targetVolume)
    {
        while (_alarm.volume != targetVolume)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _soundChangingSpeed * Time.deltaTime);

            yield return null;
        }

        if (_alarm.volume == _minVolume) 
        {
            _alarm.Stop();
        }
    }
}
