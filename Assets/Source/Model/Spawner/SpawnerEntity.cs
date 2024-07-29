using System;
using UnityEngine;

public class SpawnerEntity
{
    private readonly EntityViewFactory _factory;

    public SpawnerEntity(EntityViewFactory factory)
    {
        _factory = factory;
    }

    public void Spawn(Entity entity,Transform[] points, int lengch)
    {
        Exception.TryValueIsInvalideit(lengch);

        if (points.Length < lengch)
            throw new InvalidOperationException();

        for (int i = 0; i < lengch; i++)
            _factory.Creat(points[i], entity);
    }
}
