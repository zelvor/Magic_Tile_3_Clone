using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePool : ObjectPool<Tile>
{
    [SerializeField]
    private int poolSize = 8;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            base.Add();
        }
    }
    public override void Return(Tile obj)
    {
        base.Return(obj);
        obj.transform.parent = transform;
    }
}
