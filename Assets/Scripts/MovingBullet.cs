using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MovingBullet : MonoBehaviour
{
    [SerializeField] private Transform _allPlacesPoint;
    [SerializeField] private float _movementSpeed;
    
    private Transform[] _arrayPlaces;

    private int _indexCurrentPointWhichObjectMoving;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
        {
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform _pointByNumberInArray = _arrayPlaces[_indexCurrentPointWhichObjectMoving];

        transform.position = Vector3.MoveTowards(transform.position, _pointByNumberInArray.position, _movementSpeed * Time.deltaTime);

        if (transform.position == _pointByNumberInArray.position)
        {
            MovementToNextPoint();
        }
    }

    public Vector3 MovementToNextPoint()
    {
        int startingObjectNumber = 0;

        _indexCurrentPointWhichObjectMoving++;

        if (_indexCurrentPointWhichObjectMoving == _arrayPlaces.Length)
        {
            _indexCurrentPointWhichObjectMoving = startingObjectNumber;
        }

        Vector3 pointVector = _arrayPlaces[_indexCurrentPointWhichObjectMoving].transform.position;

        transform.forward = pointVector - transform.position;

        return pointVector;
    }
}
