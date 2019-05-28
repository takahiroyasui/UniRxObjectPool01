using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class MainScript : MonoBehaviour
{
    private CubePool cubePool;
    [SerializeField] private CubeScript cubePrefab;


    public void OnClick()
    {
        // Instantiate(cube, new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), transform.position.z), transform.rotation);

        var position =  new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), transform.position.z);

        var cube = cubePool.Rent();

        cube.Generate(position)
        .Subscribe(_ => {
            if (cube == null) {
                Debug.Log("cube is null");
            } else {
                Debug.Log("cube is not null");
            }
            cubePool.Return(cube);
        });
        
    }

    void Start()
    {
        cubePool = new CubePool(cubePrefab);
        this.OnDestroyAsObservable()
        .Subscribe(_ => {
            Debug.Log("dipose");
            cubePool.Dispose();
        });
    }

    void Update()
    {
        
    }
}
