using UnityEngine;

public class PhysicsEventBroadcaster : MonoBehaviour
{
    private object _model;
    private PhysicsRouter _router;

    public void Init(object model, PhysicsRouter router)
    {
        _model = model;
        _router = router;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PhysicsEventBroadcaster broadcaster))
            _router.TryAddCollision(_model, broadcaster._model);
    }
}
