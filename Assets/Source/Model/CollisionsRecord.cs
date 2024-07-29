using System;
using System.Collections.Generic;
using static PhysicsRouter;

public class CollisionsRecord
{
    public IEnumerable<Record> Values()
    {
        yield return null;
    }

    private Record IfCollided<T1, T2>(Action<T1, T2> action)
    {
        return new Record<T1, T2>(action);
    }
}