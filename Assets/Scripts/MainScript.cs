using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MainScript : MonoBehaviour
{
    [SerializeField] private CubeScript cubePrefab;
    private CubePool cubePool;

    public void OnClick()
    {
        var position = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), transform.position.z);

        var cube = cubePool.Rent();

        cube.Generate(position)
            .Subscribe(_ => cubePool.Return(cube))
            .AddTo(this);
    }

    void Start()
    {
        cubePool = new CubePool(cubePrefab);

        this.OnDestroyAsObservable()
            .Subscribe(_ => {
                Debug.Log("dipose");
                cubePool.Dispose();
            }).AddTo(this);
    }
}
