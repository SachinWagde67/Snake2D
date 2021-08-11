using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : BodyPart
{
    private Vector2 movement;
    private BodyPart tail;
    const float TimeToAddBodyPart = 0.1f;
    float addtimer = TimeToAddBodyPart;

    [HideInInspector] public int partsToAdd = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetMovement(movement);
        UpdateDirection();
        UpdatePosition();
        SnakeMovement();

        if (partsToAdd > 0)
        {
            addtimer -= Time.deltaTime;
            if(addtimer <= 0)
            {
                addtimer = TimeToAddBodyPart;
                AddBodyPart();
                partsToAdd--;
            }
        }
    }

    private void SnakeMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movement = Vector2.up * Time.fixedDeltaTime * GameController.instance.snakeSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movement = Vector2.down * Time.fixedDeltaTime * GameController.instance.snakeSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movement = Vector2.left * Time.fixedDeltaTime * GameController.instance.snakeSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movement = Vector2.right * Time.fixedDeltaTime * GameController.instance.snakeSpeed;
        }
    }

    private void AddBodyPart()
    {
        if(tail == null)
        {
            Vector3 newPos = transform.position;
            newPos.z += 0.01f;

            BodyPart newpart = Instantiate(GameController.instance.bodyPrefab, newPos, Quaternion.identity);
            newpart.follow = this;
            tail = newpart;
            newpart.ChangeToTail();
        }
        else
        {
            Vector3 newPos = tail.transform.position;
            newPos.z += 0.01f;

            BodyPart newpart = Instantiate(GameController.instance.bodyPrefab, newPos, Quaternion.identity);
            newpart.follow = tail;
            newpart.ChangeToTail();
            tail.ChangeToBodyPart();
            tail = newpart;
        }
    }

    public void ResetSnake()
    {
        tail = null;
        partsToAdd = 3;
        addtimer = TimeToAddBodyPart;
    }
}
