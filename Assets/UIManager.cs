using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionText;

    
    private void Awake()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
    }

    private void OnGameStart()
    {
        instructionText.gameObject.SetActive(false);
    }

}
