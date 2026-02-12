using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    Vector3 _lastCoordinatePos;
     AudioSource _audioSource;
    [SerializeField] GameObject _debrisPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            _lastCoordinatePos = other.transform.position;
            //Debug.Log(_lastCoordinateHit);
        }
        if (other.gameObject.layer == 10)
        {
            DestroyRobot();
        }
    }
    void DestroyRobot()
    {
        PlayDeathSound();
        Vector3 debrisSpawnPos = new Vector3(_lastCoordinatePos.x,0, _lastCoordinatePos.z);
        Instantiate(_debrisPrefab, debrisSpawnPos, Quaternion.identity);
        Destroy(gameObject);
    }

      public void PlayDeathSound()
    {
        SoundManager.instance.PlayClipOnSource(_audioSource, SoundManager.instance.GetGegnerDeathSound(), 1f, false);
    }
}
