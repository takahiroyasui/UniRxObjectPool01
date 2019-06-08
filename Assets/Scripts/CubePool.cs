using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

public class CubePool : ObjectPool<CubeScript>
{
    private readonly CubeScript prefab;

    public CubePool(CubeScript prefab)
    {
        this.prefab = prefab;
    }

    protected override CubeScript CreateInstance()
    {
        return GameObject.Instantiate(prefab);
    }
}
