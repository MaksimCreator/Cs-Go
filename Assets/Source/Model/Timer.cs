using System;
using UniRx;

public class Timer
{
    private readonly CompositeDisposable _time = new();

    public static float ElapsedTime { get; private set; }

    public static CompositeDisposable StartTimer(float cooldown,Action onEnd)
    {
        CompositeDisposable disposables = new();

        Observable.Timer(TimeSpan.FromSeconds(cooldown))
            .Subscribe(_ =>
            {
                onEnd?.Invoke();
                disposables.Clear();
            }).AddTo(disposables);

        return disposables;
    }

    public static CompositeDisposable StartInfiniteTimer(float cooldown, Action onEnd)
    {
        CompositeDisposable disposable = new();

        Observable.Interval(TimeSpan.FromSeconds(cooldown))
            .Subscribe(_ => onEnd?.Invoke())
            .AddTo(disposable);

        return disposable;
    }

    public void StartTimer()
    {
        Observable.Interval(TimeSpan.FromSeconds(0.1f))
            .Subscribe(_ => ElapsedTime += 0.1f)
            .AddTo(_time);
    }

    public float GetTime()
    {
        _time.Clear();
        float time = ElapsedTime;
        ElapsedTime = 0f;
        return time;
    }
}