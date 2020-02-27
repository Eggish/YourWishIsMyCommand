using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro TextMesh;

    private int PlayerPoints = 0;

    private string PointText = "";

    void Start()
    {
        PointText = TextMesh.text;
        AlterPoints(0);
    }

    public void AlterPoints(int pPointChange)
    {
        PlayerPoints += pPointChange;
        TextMesh.text = PointText + PlayerPoints;
    }
}
