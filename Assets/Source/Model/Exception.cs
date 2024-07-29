using System;

public static class Exception
{
    public static void TryValueIsInvalideit(float delta)
    {
        if (delta <= 0)
            throw new InvalidOperationException(nameof(delta));
    }
}