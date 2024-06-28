using UnityEngine;

[RequireComponent(typeof(Collider))]
public class IntruderDetector : MonoBehaviour
{
    [SerializeField] private AlarmPlayer _alarm;

    private void OnTriggerEnter(Collider intruder)
    {
        if (intruder.GetComponent("Walker") == true)
        {
            _alarm.TurnOn();
        }
    }
    private void OnTriggerExit(Collider intruder)
    {
        if (intruder.GetComponent("Walker") == true)
        {
            _alarm.TurnOff();
        }
    }
}
