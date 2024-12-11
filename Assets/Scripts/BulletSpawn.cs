using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private Cartridge _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _intervalBetweenShots;

    private void Start()
    {
        StartCoroutine(Shooter());
    }

    private IEnumerator Shooter()
    {
        Vector3 bulletDirection;
        Cartridge newBullet;

        bool isWork = true;

        while (isWork)
        {
            bulletDirection = (_target.position - transform.position).normalized;
            newBullet = Instantiate(_bullet, transform.position + bulletDirection, Quaternion.identity);

            newBullet.ChangeDirectionBullet.transform.up = bulletDirection;
            newBullet.ChangeBulletSpeed.linearVelocity = bulletDirection * _bulletSpeed;

            yield return new WaitForSeconds(_intervalBetweenShots);
        }
    }
}
