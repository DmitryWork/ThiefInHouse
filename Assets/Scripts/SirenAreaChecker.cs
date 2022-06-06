using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class SirenAreaChecker : MonoBehaviour
{
    private Alarm _alarm;

    private void Awake()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _alarm.Work(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _alarm.Work(false);
        }
    }
}