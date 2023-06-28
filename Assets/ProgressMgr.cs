using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressMgr : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {   
        slider = GetComponent<Slider>();
        GameManager.Instance.OnAddScore += IncreaseProgress;
    }
    
    private void IncreaseProgress()
    {
        slider.value += 0.02f;
    }


}
