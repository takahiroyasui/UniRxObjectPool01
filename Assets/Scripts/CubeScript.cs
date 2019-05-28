using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CubeScript : MonoBehaviour
{
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(2f))
        .Subscribe(_ => Destroy(gameObject))
        .AddTo(this);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }

    public IObservable<long> Generate(Vector3 position)
    {
        transform.position = position;
        

        return Observable.Timer(TimeSpan.FromSeconds(2.0f))
        .SubscribeOn(Scheduler.ThreadPool)
        .ObserveOnMainThread();
    }
}
