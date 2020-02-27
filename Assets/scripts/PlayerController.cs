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
    [SerializeField] private float SpriteSwitchbackDelay = 0.5f;

    [SerializeField] private Sprite DefaultSprite = null;
    [SerializeField] private Sprite PickupSprite = null;
    [SerializeField] private SpriteRenderer SpriteRenderer = null;

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
        SpriteRenderer.sprite = PickupSprite;
        Invoke("SwitchBackSprite", SpriteSwitchbackDelay);
    }

    private void SwitchBackSprite()
    {
        SpriteRenderer.sprite = DefaultSprite;
    }

}
