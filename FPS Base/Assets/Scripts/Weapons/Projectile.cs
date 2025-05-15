using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _lifeTime = 1f;
    private float _damage;
    private Rigidbody _rb;

    private void Initialize(float dmgValue)
    {   
        _damage = dmgValue;  
    }

    private void Awake()
    {
        // Cache the bullets Rigidbody compoent at Start
        _rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        // Make the bullet move when fired
        _rb.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
