using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Tile is fall down
    private float speed = 10f;

    private float alpha = 0.5f;

    private bool isClicked = false;

    private bool gameOver = false;

    private float gameOverHeight = -6f;

    private float stopHeight = -8f;

    private float stopOffset = 0.5f;

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y < gameOverHeight && !isClicked)
            {
                MoveTilesUp();
                gameOver = true;
                GameManager.Instance.OnGameOver?.Invoke();
            }

            if (transform.position.y < stopHeight)
            {
                ReturnTile();
            }
        }
    }

    private void OnMouseDown()
    {
        isClicked = true;
        GameManager.Instance.OnAddScore?.Invoke();
        ScoreEffectMgr.Instance.ShowEffect(transform.position.y);
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().color =
            new Color(1f, 1f, 1f, alpha);
    }

    private void MoveTilesUp()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach (Tile tile in tiles)
        {
            tile.StopFalling();
            tile.MoveUp();

            // all tiles are untouchable after game over
            tile.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void MoveUp()
    {
        float targetY = transform.position.y + 2f; // Move up by 1 unit
        transform.DOMoveY(targetY, 1f).SetEase(Ease.OutBack);
        speed = 0f;
    }

    public void StopFalling()
    {
        float targetY = transform.position.y + stopOffset;
        transform.position =
            new Vector3(transform.position.x, targetY, transform.position.z);
        speed = 0f;
    }

    public void ReturnTile()
    {
        gameObject.GetComponent<SpriteRenderer>().color =
            new Color(1f, 1f, 1f, 1f);
        isClicked = false;
        TilePool.Instance.Return(this);
    }
}
