using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private int _currentPoint;
    private Transform[] _points;

    private void Start()
    {
        SetPoints();
    }

    private void Update()
    {
        Move();
    }

    private void SetPoints()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Move()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _path.childCount)
            {
                _currentPoint = 0;
            }
        }
    }
}