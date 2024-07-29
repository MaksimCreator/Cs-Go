using UnityEngine;

[RequireComponent(typeof(PhysicsEventBroadcaster))]
public class PartBody : MonoBehaviour
{
    [SerializeField] private float _factorDamage;
    [SerializeField] private PhysicsCompositRoot _physics;

    private Health _health;

    public void Init(Health healthBody)
    {
        _health = healthBody;
        PhysicsEventBroadcaster broadcaster = GetComponent<PhysicsEventBroadcaster>();
        broadcaster.Init(this, _physics.Router);
    }

    public void TakeDamage(float damage)
    => _health.TakeDamage((int)(damage * _factorDamage));
}