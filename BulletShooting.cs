using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private Bullet _bulletPrefab;

    public float BulletSpeed;
    public Transform Target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isFiring = enabled;

        while (isFiring)
        {
            var directionVector = (Target.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = directionVector;
            newBullet.GetComponent<Rigidbody>().velocity = directionVector * BulletSpeed;

            yield return new WaitForSeconds(_timeBetweenShots);
        }
    }
}