using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class TempScript : MonoBehaviour
{
    [SerializeField] Button button2;
    private CubePool cubePool;
    [SerializeField] private CubeScript cubePrefab;

    void Start()
    {
        cubePool = new CubePool(cubePrefab);
        this.OnDestroyAsObservable()
        .Subscribe(_ => {
            Debug.Log("dipose");
            cubePool.Dispose();
        });

        button2.OnClickAsObservable()
        .Subscribe(_ => {
            Debug.Log("ok");
        
            var position =  new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), transform.position.z);
            var cube = cubePool.Rent();

            cube.Generate(position)
            .Subscribe(__ => {
                if (cube == null) {
                    Debug.Log("cube is null");
                } else {
                    Debug.Log("cube is not null");
                }
                cubePool.Return(cube);
            });
        });
    }

    void Update()
    {
        
    }
}
