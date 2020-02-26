using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Validator : MonoBehaviour
{
    [SerializeField] private TextMeshPro Sentence = null;
    [SerializeField] private WordSpawner Spawner = null;
    [SerializeField] private PointManager PointManager = null;

    public void AddWord(GameObject pWordToAdd)
    {
        pWordToAdd.SetActive(false);
        Sentence.text += pWordToAdd.GetComponent<TextMeshPro>().text;
        Sentence.text += " ";
    }

    public void LockInChoice()
    {
        ValidateSentence();
        Sentence.text = "";
    }

    private void ValidateSentence()
    {
        SentenceWrapper[] Sentences = Spawner.GetSentences();

        foreach (var t in Sentences)
        {
            if (t.Sentence + " " == Sentence.text)
            {
                PointManager.AlterPoints(t.PointValue);
                return;
            }
        }
        Debug.Log("Player got no points, nonsense Sentence");
    }
}
