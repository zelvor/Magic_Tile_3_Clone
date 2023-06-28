using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandIntro : MonoBehaviour
{
    //DOTWeen Move from (-0.2, -1.8) to 1.2, -3.6

    void Awake()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
    }

    void Start()
    {
        transform.position = new Vector3(-0.2f, -1.8f, 0);
        transform.DOMove(new Vector3(1.2f, -3.6f, 0), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnGameStart()
    {
        gameObject.SetActive(false);
    }

    

}
