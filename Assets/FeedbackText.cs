using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackText : MonoBehaviour
{
    [SerializeField] private TextMeshPro TextMesh = null;

    [SerializeField] private float UpSpeed = 5.0f;
    [SerializeField] private float FadeOutSpeed = 1.0f;

    void Start()
    {
        if (TextMesh == null)
            TextMesh = GetComponent<TextMeshPro>();
        StartCoroutine(FadeOut());
    }

    void Update()
    {
        transform.position += new Vector3(0, UpSpeed * Time.deltaTime, 0);
    }

    private IEnumerator FadeOut()
    {
        while (TextMesh.alpha > 0)
        {
            TextMesh.alpha -= FadeOutSpeed * Time.deltaTime;
            yield return null;
        }
        Destroy(this);
        yield return null;
    }
}
