using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private Vector3 _destination;
    private int _currentIndex;
    private float _walkSpeed;

    private void Awake()
    {
        _currentIndex = 0;
        _destination = _waypoints[_currentIndex].position;
        _walkSpeed = 1f;
    }

    private void Update()
    {
        if(transform.position == _destination)
        {
            ChangeDestination();
        }

        transform.position = Vector3.MoveTowards(transform.position, _destination, _walkSpeed * Time.deltaTime);
    }

    private void ChangeDestination()
    {
        _currentIndex = Mathf.Abs(_currentIndex - (_waypoints.Length - 1));
        _destination = _waypoints[_currentIndex].position;
    }
}
