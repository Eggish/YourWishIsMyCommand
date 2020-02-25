using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Word : MonoBehaviour
{
    [SerializeField] private TextMeshPro Text = null;

    [SerializeField] private BoxCollider2D Collider = null;

    [SerializeField] private float MovementSpeed = 5.0f;

    [HideInInspector] public int PointValue = 0;
    private Vector3 HeadingDirection = Vector3.zero;

    void Start()
    {
        if(Text == null)
        {
            Text = GetComponent<TextMeshPro>();
        }
        if(Collider == null)
        {
            Collider = GetComponent<BoxCollider2D>();
        }
        Destroy(this, 10);
    }

    void Update()
    {
        if(HeadingDirection != Vector3.zero)
        {
            transform.position += HeadingDirection * MovementSpeed * Time.deltaTime;
        }
    }

    public void SetDirection(Direction pDirection)
    {
        switch(pDirection)
        {
            case Direction.NORTH:
                HeadingDirection = Vector3.down;
                break;
            case Direction.EAST:
                HeadingDirection = Vector3.left;
                break;
            case Direction.SOUTH:
                HeadingDirection = Vector3.up;
                break;
            case Direction.WEST:
                HeadingDirection = Vector3.right;
                break;
        }
    }
}
