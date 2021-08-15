using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake2 : MonoBehaviour
{
    private Vector2 direction = Vector2.up;
    private List<Transform> segments = new List<Transform>();
    private bool l = false, r = false, u = true, d = false;
    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform SnakeSegmentPrefab;
    [SerializeField] private int initialSize;
    [SerializeField] private BoxCollider2D wallArea;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject ScoreScreen;

    private void Start()
    {
        Time.timeScale = 1f;
        GameOverScreen.SetActive(false);
        ScoreScreen.SetActive(true);
        ResetGame();
        Bounds bound = wallArea.bounds;
        minX = bound.min.x;
        maxX = bound.max.x;
        minY = bound.min.y;
        maxY = bound.max.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!d)
            {
                u = true;
                l = false;
                r = false;
                direction = Vector2.up;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!u)
            {
                d = true;
                l = false;
                r = false;
                direction = Vector2.down;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (!r)
            {
                u = false;
                d = false;
                l = true;
                direction = Vector2.left;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!l)
            {
                r = true;
                u = false;
                d = false;
                direction = Vector2.right;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, -90);
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        ScreenWrap();

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y,
            0f);
    }

    private void ScreenWrap()
    {
        Vector3 newPos = transform.position;

        if (newPos.x > maxX)
        {
            newPos.x = -newPos.x + 1f;
        }
        else if (newPos.x <= minX)
        {
            newPos.x = -newPos.x - 1f;
        }

        if (newPos.y >= maxY)
        {
            newPos.y = -newPos.y + 1f;
        }
        else if (newPos.y <= minY)
        {
            newPos.y = -newPos.y - 1f;
        }

        transform.position = newPos;
    }

    private void Grow()
    {
        Transform segment = Instantiate(SnakeSegmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void Reduce()
    {
        Transform segment = segments[segments.Count - 1].transform;
        segments.Remove(segment);
        Destroy(segment.gameObject);
    }

    private void ResetGame()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        for (int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(SnakeSegmentPrefab));
        }

        //gameObject.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            gameManager.Score2Increment(7f);
            Grow();
        }
        else if (other.CompareTag("obstacle"))
        {
            GameOverScreen.SetActive(true);
            ScoreScreen.SetActive(false);
            Time.timeScale = 0f;
        }
        else if (other.CompareTag("rock"))
        {
            gameManager.Score2Decrement(5f);
            if (segments.Count > 3)
            {
                Reduce();
            }
        }
        else if (other.CompareTag("scoreboost"))
        {
            gameManager.Score2Double(gameManager.WhatIsScore2());
        }
        else if (other.CompareTag("shield"))
        {

        }
    }
}
