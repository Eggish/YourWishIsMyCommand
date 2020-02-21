using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Word : MonoBehaviour
{
    [SerializeField] private TextMeshPro Text = null;

    [SerializeField] private BoxCollider2D Collider = null;

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
        //Collider.bounds = Text.textBounds;
    }

    void Update()
    {
        
    }
}
