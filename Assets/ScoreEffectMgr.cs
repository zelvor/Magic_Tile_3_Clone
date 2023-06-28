using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreEffectMgr : Singleton<ScoreEffectMgr>
{
    [SerializeField] private Image perfectImage;
    [SerializeField] private Image greatImage;
    [SerializeField] private Image coolImage;

    protected override void Awake()
    {
        base.Awake();
    }

    public void ShowEffect(float posY){
        // if posY from -2.2f to 0.2f, perfect
        // if posY from -3.4f to 1.4f, great
        // else cool
        if(posY >= -2.2f && posY <= 0.2f){
            perfectImage.gameObject.SetActive(true);
            AnimationEffect(perfectImage);
            greatImage.gameObject.SetActive(false);
            coolImage.gameObject.SetActive(false);
        }
        else if(posY >= -3.4f && posY <= 1.4f){
            greatImage.gameObject.SetActive(true);
            AnimationEffect(greatImage);
            perfectImage.gameObject.SetActive(false);
            coolImage.gameObject.SetActive(false);
        }
        else{
            coolImage.gameObject.SetActive(true);
            AnimationEffect(coolImage);
            perfectImage.gameObject.SetActive(false);
            greatImage.gameObject.SetActive(false);
        }
    }

    public void AnimationEffect(Image image){
        image.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f, 10, 1).OnComplete(() => {
            image.transform.localScale = Vector3.one * 1.5f;
        });
    }
}
