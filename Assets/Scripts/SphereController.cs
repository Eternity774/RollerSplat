using System;
using UnityEngine;
using UnityEngine.Events;

public enum MoveDirection
{
    Up,
    Down,
    Right,
    Left,
    Stop
}

public class SphereController : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody rb;

    MoveDirection moveDir = MoveDirection.Stop;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    print("Collision!!!");
    //    moveDir = MoveDirection.Stop;
    //}

    private void Update()
    {
        switch (moveDir)
        {
            case MoveDirection.Stop:
                {
                    break;
                }
            case MoveDirection.Up:
                {
                    rb.velocity = Vector3.forward * speed * Time.deltaTime;
                    //transform.Translate(transform.forward * Time.deltaTime * speed);
                    break;
                }
            case MoveDirection.Down:
                {
                    rb.velocity = Vector3.back * speed * Time.deltaTime;
                    //transform.Translate(-transform.forward * Time.deltaTime * speed);
                    break;
                }
            case MoveDirection.Right:
                {
                    rb.velocity = Vector3.right * speed * Time.deltaTime;
                    //transform.Translate(transform.right * Time.deltaTime * speed);
                    break;
                }
            case MoveDirection.Left:
                {
                    rb.velocity = Vector3.left * speed * Time.deltaTime;
                    //transform.Translate(-transform.right * Time.deltaTime * speed);
                    break;
                }
        }
    }

    public void MoveRight()
    {
        moveDir = MoveDirection.Right;
    }

    public void MoveLeft()
    {
        moveDir = MoveDirection.Left;
    }

    public void MoveUp()
    {
        moveDir = MoveDirection.Up;
    }
    public void MoveDown()
    {
        moveDir = MoveDirection.Down;
    }
}

