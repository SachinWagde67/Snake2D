using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private Vector2 position;
    [HideInInspector] public BodyPart follow;
    private bool isTail = false;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovement(Vector2 movement)
    {
        position = movement;
    }

    public void UpdatePosition()
    {
        gameObject.transform.position += (Vector3)position;
    }

    public void UpdateDirection()
    {
        if (position.y > 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        else if (position.y < 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
        else if (position.x < 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
        else if (position.x > 0)
            gameObject.transform.localEulerAngles = new Vector3(0, 0, -90);
    }

    public void ChangeToTail()
    {
        isTail = true;
        sr.sprite = GameController.instance.tailSprite;
    }

    public void ChangeToBodyPart()
    {
        isTail = false;
        sr.sprite = GameController.instance.bodyPartSprite;
    }
}
