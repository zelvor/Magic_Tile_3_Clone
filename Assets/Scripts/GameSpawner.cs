using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    private List<float> timeList = new List<float>();

    [SerializeField]
    private PositionSpawner[] positionSpawner;

    private bool isGameOver = false;

    private void Awake()
    {
        timeList =
            new List<float>()
            {
                0.51923f,
                0.46153802f,
                0.46153802f,
                0.46153796f,
                0.92307603f,
                0.46153808f,
                0.23076892f,
                0.23076892f,
                0.46153808f,
                0.46153784f,
                0.23076916f,
                0.23076916f,
                0.46153784f,
                0.46153784f,
                0.23076916f,
                0.23076916f,
                0.46153784f,
                0.46153784f,
                0.4615383f,
                0.4615383f,
                0.2307682f,
                0.23076916f,
                0.4615383f,
                0.4615383f,
                0.2307682f,
                0.23076916f,
                0.4615383f,
                0.23076916f,
                0.23076916f,
                0.46153736f,
                0.6923075f,
                0.23076916f,
                0.2307682f,
                0.23076916f,
                0.23076916f,
                0.23076916f,
                0.22596169f,
                0.23557663f,
                0.46153736f,
                0.23076916f,
                0.23076916f,
                0.4615383f,
                0.46153736f,
                0.23076916f,
                0.2307682f,
                0.4615383f,
                0.4615383f,
                0.23077011f,
                0.2307682f,
                0.4615383f,
                0.4615383f,
                0.4615364f
            };

        GameManager.Instance.OnGameStart += OnGameStart;
        GameManager.Instance.OnGameOver += OnGameOver;
    }

    private void OnGameStart()
    {
        isGameOver = false; // Reset the game over flag
        StartCoroutine(SpawnPositionSpawnerRoutine());
    }

    private void OnGameOver()
    {
        isGameOver = true; // Set the game over flag
    }

    IEnumerator SpawnPositionSpawnerRoutine()
    {
        int previousIndex = -1;
        for (int i = 0; i < timeList.Count; i++)
        {
            if (isGameOver) yield break; // Exit the coroutine if the game is over

            int index = Random.Range(0, positionSpawner.Length);
            if (index == previousIndex)
            {
                index = (index + 1) % positionSpawner.Length;
            }
            previousIndex = index;
            positionSpawner[index].GetTile();
            yield return new WaitForSeconds(timeList[i]);
        }

        yield return new WaitForSeconds(3f); // Wait for 3 seconds after the last spawn
        GameManager.Instance.OnGameOver?.Invoke();
    }
}
