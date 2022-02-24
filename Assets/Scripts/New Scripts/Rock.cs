using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public BoxCollider2D GridArea;

    private void Start()
    {
        StartCoroutine(ChangePosition());
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.GridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }

    private IEnumerator ChangePosition()
    {
        RandomizePosition();
        yield return new WaitForSeconds(Random.Range(10f,20f));
        StartCoroutine(ChangePosition());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) || (other.CompareTag("Player2")))
        { 
            RandomizePosition();
        }
    }
}
