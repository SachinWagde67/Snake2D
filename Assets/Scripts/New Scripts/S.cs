using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class S : MonoBehaviour
{
    private Vector2 direction = Vector2.up;
    private List<Transform> segments = new List<Transform>();
    private bool l = false, r = false, u = true, d= false;

    [SerializeField] private  Transform SnakeSegmentPrefab;
    [SerializeField] private int initialSize;

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if(!u)
            {
                d = true;
                l = false;
                r = false;
                direction = Vector2.down;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(!r)
            {
                u = false;
                d = false;
                l = true;
                direction = Vector2.left;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if(!l)
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
        for (int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        transform.position = new Vector3(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y,
            0f);
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

        gameObject.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.CompareTag("obstacle"))
        {
            ResetGame();
        }
        else if (other.CompareTag("rock"))
        {
            if (segments.Count > 3)
            {
                Reduce();
            }
        }
    }
}
