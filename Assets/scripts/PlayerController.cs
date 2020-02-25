using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode UpKey = KeyCode.W;
    [SerializeField] private KeyCode RightKey = KeyCode.D;
    [SerializeField] private KeyCode DownKey = KeyCode.S;
    [SerializeField] private KeyCode LeftKey = KeyCode.A;

    [SerializeField] private float MaxSpeed = 5.0f;

    [SerializeField] private float TimeToFullSpeed = 0.5f;
    [SerializeField] private float TimeToNoSpeed = 0.5f;

    [SerializeField] private Rigidbody RB = null;

    void Start()
    {
        
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.GetKey(UpKey))
            Accelerate(Direction.NORTH);
        if (Input.GetKeyDown(RightKey))
            Accelerate(Direction.EAST);
        if (Input.GetKeyDown(DownKey))
            Accelerate(Direction.SOUTH);
        if (Input.GetKeyDown(LeftKey))
            Accelerate(Direction.WEST);

        if (!Input.GetKeyDown(UpKey)
            || !Input.GetKeyDown(RightKey)
            || !Input.GetKeyDown(DownKey)
            || !Input.GetKeyDown(LeftKey))
            Decelerate();
    }

    private void Accelerate(Direction pDirection)
    {
        switch(pDirection)
        {
            case Direction.NORTH:
                RB.velocity += Vector3.up * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
                break;
            case Direction.EAST:
                RB.velocity += Vector3.right * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
                break;
            case Direction.SOUTH:
                RB.velocity += Vector3.down * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
                break;
            case Direction.WEST:
                RB.velocity += Vector3.left * (MaxSpeed / TimeToFullSpeed) * Time.deltaTime;
                break;
        }
    }
    private void Decelerate()
    {
        float velocityMagnitude = RB.velocity.magnitude;

        velocityMagnitude -= (MaxSpeed / TimeToNoSpeed) * Time.deltaTime;
        if(velocityMagnitude < 0)
        {
            velocityMagnitude = 0;
        }

        RB.velocity = RB.velocity.normalized * velocityMagnitude;
    }
}
