using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RecoilWeapon
{
    private const float TimeSwithIndex = 0.1f;
    private const int StartWay = -1;

    private readonly Transform _musselPosition;
    private readonly List<Vector3> _way;

    private CompositeDisposable _dissposble;
    private int _index = StartWay;

    public RecoilWeapon(Transform musselPosition, List<Vector3> way)
    {
        _musselPosition = musselPosition;
        _way = way;
    }

    public void RestarRecoil()
    => _dissposble = Timer.StartInfiniteTimer(TimeSwithIndex, BackIndex);

    public Vector3 GetDirection()
    {
        if (_index++ > _way.Count)
            throw new InvalidOperationException();

        if(_index++ == _way.Count)
            _index = StartWay;

        if (_dissposble.IsDisposed == false)
            _dissposble.Dispose();

        _index++;
        return _way[_index];
    }

    private void BackIndex()
    {
        _index--;

        if (_index == StartWay)
            _dissposble.Dispose();
    }
}