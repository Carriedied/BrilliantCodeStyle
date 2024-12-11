using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cartridge : MonoBehaviour
{
    public Renderer ChangeDirectionBullet { get; private set; }
    public Rigidbody ChangeBulletSpeed { get; private set; }

    private void Awake()
    {
        ChangeDirectionBullet = GetComponent<Renderer>();
        ChangeBulletSpeed = GetComponent<Rigidbody>();
    }
}
