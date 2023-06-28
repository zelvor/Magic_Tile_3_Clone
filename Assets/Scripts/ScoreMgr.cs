using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreMgr : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
  
    private void Awake(){
        GameManager.Instance.OnAddScore += AddScore;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }
    private void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        ScoreAnimation();
    }

    private void ScoreAnimation()
    {
        // sử dụng DOTween để tạo animation
        scoreText.transform.DOPunchScale(Vector3.one * 0.5f, 0.3f, 10, 1).OnComplete(() => {
            scoreText.transform.localScale = Vector3.one;
        });
    }

}
