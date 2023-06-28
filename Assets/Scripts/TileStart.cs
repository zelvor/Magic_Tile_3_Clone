using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStart : MonoBehaviour
{

    private void Awake()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
    }

    private void OnGameStart()
    {
        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.OnGameStart?.Invoke();
    }
    
}
