using System;
using UnityEngine;

public class SpawnerEntity
{
    private readonly EntityViewFactory _factory;
    private readonly Action _deathPlayer;
    private readonly Action _deathAI;

    public SpawnerEntity(EntityViewFactory factory,Action deathPlayer,Action deathAI)
    {
        _factory = factory;
        _deathPlayer = deathPlayer;
        _deathAI = deathAI;
    }

    public void Spawn(Entity entity,Transform[] points, int lengch)
    {
        Exception.TryValueIsInvalideit(lengch);

        if (points.Length < lengch)
            throw new InvalidOperationException();

        for (int i = 0; i < lengch; i++)
        {
            Health health = new Health();

            // можно было бы создать visiter есле бы типов было больше, а так зачем он нужен
            if (entity.TypeEntity == TypeEntity.Player)
                health.onDead += () => Death(_deathPlayer,health);
            else if (entity.TypeEntity == TypeEntity.AI)
                health.onDead += () => Death(_deathAI,health);

            _factory.Creat(points[i], entity, (model,prefab) => InitChildrenObject(prefab,health));
        }
     
        void Death(Action action,Health health)
        {
            action?.Invoke();
            health.onDead -= () => Death(action,health);
        }
    }

    private void InitChildrenObject(GameObject model,Health TypeInit)
    {
        foreach (var item in model.GetComponentsInChildren<PartBody>())
            item.Init(TypeInit);
    }
}