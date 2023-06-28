using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // play music after 0.8 second
    private float delayTime = 0.7f;

    private AudioSource audioSource;

    private void Awake()
    {
        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnGameOver += OnGameOver;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnGameStart()
    {
        StartCoroutine(PlayMusicRoutine());
    }

    IEnumerator PlayMusicRoutine()
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.Play();
    }

    private void OnGameOver()
    {
        audioSource.Stop();
    }
}
