using UnityEngine;

public class TravelLocations : MonoBehaviour
{
    [SerializeField] private Transform[] locations;

    private int _currentLocationIndex = 0;

    public float MovementSpeed;
    public Transform LocationsParent;

    private void Start()
    {
        locations = new Transform[LocationsParent.childCount];

        for (int i = 0; i < LocationsParent.childCount; i++)
            locations[i] = LocationsParent.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var currentLocation = locations[_currentLocationIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentLocation.position, MovementSpeed * Time.deltaTime);

        if (transform.position == currentLocation.position) NextLocation();
    }

    private void NextLocation()
    {
        _currentLocationIndex++;

        if (_currentLocationIndex == locations.Length)
            _currentLocationIndex = 0;

        var nextLocationVector = locations[_currentLocationIndex].transform.position;
        transform.forward = nextLocationVector - transform.position;
    }
}
