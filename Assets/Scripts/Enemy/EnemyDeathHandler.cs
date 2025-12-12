using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    Vector3 _lastCoordinatePos;
    [SerializeField] GameObject _debrisPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coordinate"))
        {
            _lastCoordinatePos = other.transform.position;
            //Debug.Log(_lastCoordinateHit);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            DestroyRobot();
        }
    }
    void DestroyRobot()
    {
        Vector3 debrisSpawnPos = new Vector3(_lastCoordinatePos.x,0, _lastCoordinatePos.z);
        Instantiate(_debrisPrefab, debrisSpawnPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
