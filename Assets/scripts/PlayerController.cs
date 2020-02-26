using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode UpKey = KeyCode.W;
    [SerializeField] private KeyCode RightKey = KeyCode.D;
    [SerializeField] private KeyCode DownKey = KeyCode.S;
    [SerializeField] private KeyCode LeftKey = KeyCode.A;
    [SerializeField] private KeyCode LockKey = KeyCode.Return;

    [SerializeField] private float MovementSpeed = 6.0f;

    //[SerializeField] private float MaxSpeed = 5.0f;

    //[SerializeField] private float TimeToFullSpeed = 0.5f;
    //[SerializeField] private float TimeToNoSpeed = 0.5f;

    //[SerializeField] private Rigidbody2D RB = null;

    [SerializeField] private Validator Validator = null;

    void Start()
    {
        
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.GetKey(UpKey) && Input.GetKey(RightKey))
            DiagonalMove(Direction.NORTH, Direction.EAST);
        else if (Input.GetKey(RightKey) && Input.GetKey(DownKey))
            DiagonalMove(Direction.EAST, Direction.SOUTH);
        else if (Input.GetKey(DownKey) && Input.GetKey(LeftKey))
            DiagonalMove(Direction.SOUTH, Direction.WEST);
        else if (Input.GetKey(LeftKey) && Input.GetKey(UpKey))
            DiagonalMove(Direction.WEST, Direction.NORTH);
        else if (Input.GetKey(UpKey))
            Move(Direction.NORTH);
        else if (Input.GetKey(RightKey))
            Move(Direction.EAST);
        else if (Input.GetKey(DownKey))
            Move(Direction.SOUTH);
        else if (Input.GetKey(LeftKey))
            Move(Direction.WEST);

        if (Input.GetKeyDown(LockKey))
        {
            Validator.LockInChoice();
        }

        //if (Input.GetKey(UpKey))
        //    Accelerate(Direction.NORTH);
        //if (Input.GetKey(RightKey))
        //    Accelerate(Direction.EAST);
        //if (Input.GetKey(DownKey))
        //    Accelerate(Direction.SOUTH);
        //if (Input.GetKey(LeftKey))
        //    Accelerate(Direction.WEST);

        //if (!Input.GetKey(UpKey)
        //    && !Input.GetKey(RightKey)
        //    && !Input.GetKey(DownKey)
        //    && !Input.GetKey(LeftKey))
        //    Decelerate();
    }

    private void Move(Direction pDirection)
    {
        switch (pDirection)
        {
            case Direction.NORTH:
                transform.position += Vector3.up * MovementSpeed * Time.deltaTime;
                break;
            case Direction.EAST:
                transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
                break;
            case Direction.SOUTH:
                transform.position += Vector3.down * MovementSpeed * Time.deltaTime;
                break;
            case Direction.WEST:
                transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
                break;
        }
    }

    private void DiagonalMove(Direction pDirectionOne, Direction pDirectionTwo)
    {
        switch (pDirectionOne)
        {
            case Direction.NORTH:
                transform.position += Vector3.up * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
            case Direction.EAST:
                transform.position += Vector3.right * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
            case Direction.SOUTH:
                transform.position += Vector3.down * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
            case Direction.WEST:
                transform.position += Vector3.left * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
        }
        switch (pDirectionTwo)
        {
            case Direction.NORTH:
                transform.position += Vector3.up * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
            case Direction.EAST:
                transform.position += Vector3.right * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
            case Direction.SOUTH:
                transform.position += Vector3.down * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
            case Direction.WEST:
                transform.position += Vector3.left * MovementSpeed * 0.7071f * Time.deltaTime;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D pCollider2D)
    {
        Validator.AddWord(pCollider2D.gameObject);
    }



    //private void Accelerate(Direction pDirection)
    //{
    //    if (RB.velocity.magnitude > MaxSpeed)
    //        return;
    //    switch(pDirection)
    //    {
    //        case Direction.NORTH:
    //            transform.position += Vector3.up * 6 * Time.deltaTime;
    //            break;
    //        case Direction.EAST:
    //            transform.position += Vector3.right * 6 * Time.deltaTime;
    //            break;
    //        case Direction.SOUTH:
    //            transform.position += Vector3.down * 6 * Time.deltaTime;
    //            break;
    //        case Direction.WEST:
    //            transform.position += Vector3.left * 6 * Time.deltaTime;
    //            break;
    //            //case Direction.NORTH:
    //            //    RB.velocity += Vector3.up * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
    //            //    break;
    //            //case Direction.EAST:
    //            //    RB.velocity += Vector3.right * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
    //            //    break;
    //            //case Direction.SOUTH:
    //            //    RB.velocity += Vector3.down * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
    //            //    break;
    //            //case Direction.WEST:
    //            //    RB.velocity += Vector3.left * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
    //            //    break;
    //    }
    //}


    //private void Decelerate()
    //{
    //    float velocityMagnitude = RB.velocity.magnitude;

    //    velocityMagnitude -= (MaxSpeed / TimeToNoSpeed) * Time.deltaTime;
    //    if(velocityMagnitude < 0)
    //    {
    //        velocityMagnitude = 0;
    //    }

    //    RB.velocity = RB.velocity.normalized * velocityMagnitude;
    //}
}
