using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSpawner : MonoBehaviour
{
    [SerializeField] private TilePool tilePool;

    public void GetTile()
    {
        Tile tile = tilePool.Get();
        tile.transform.position = transform.position;
        tile.gameObject.SetActive(true);
    }

    public void ReturnTile(Tile tile)
    {
        tilePool.Return(tile);
    }

}
