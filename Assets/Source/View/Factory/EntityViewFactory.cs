using System;
using UnityEngine;

public class EntityViewFactory : ViewFactory<Entity>
{
    [SerializeField] private GameObject _prefabTerrorist;
    [SerializeField] private GameObject _prefabContorTerrorist;

    protected override GameObject GetTemplay(Entity entity)
    {
        if (entity is Terrorist)
            return _prefabTerrorist;
        else if(entity is ContorTerrorist)
            return _prefabContorTerrorist;

        throw new InvalidOperationException();
    }
}
