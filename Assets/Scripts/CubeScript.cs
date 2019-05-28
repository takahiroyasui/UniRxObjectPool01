using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CubeScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }

    public IObservable<long> Generate(Vector3 position)
    {
        transform.position = position;
        
        return Observable.Timer(TimeSpan.FromSeconds(2.0f));
    }
}
