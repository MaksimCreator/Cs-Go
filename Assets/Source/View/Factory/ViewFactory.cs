using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewFactory<T> : MonoBehaviour where T : class
{
    [SerializeField] private PhysicsCompositRoot _physics;

    private Dictionary<T, GameObject> _views = new();

    public void Creat(Transform parent, T model, Action<T,GameObject> Action = null, bool JoinModelToParent = false)
    {
        GameObject prefab = Instantiate(GetTemplay(model), GetPosition(parent.position),GetRotation(parent.rotation));
        _views.Add(model, prefab);
        Action?.Invoke(model,prefab);

        if(JoinModelToParent)
            prefab.transform.parent = parent;

        if (prefab.TryGetComponent(out PhysicsEventBroadcaster broadcaster))
            broadcaster.Init(model,_physics.Router);
    }

    public void Destrpy(T model)
    {
        Destroy(_views[model]);
        _views.Remove(model);
    }

    protected abstract GameObject GetTemplay(T entity);

    protected virtual Vector3 GetPosition(Vector3 parentPosition)
    => parentPosition;

    protected virtual Quaternion GetRotation(Quaternion rotation)
    => rotation;
}