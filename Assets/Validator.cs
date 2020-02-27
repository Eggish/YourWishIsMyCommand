using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Validator : MonoBehaviour
{
    [SerializeField] private TextMeshPro Sentence = null;
    [SerializeField] private WordSpawner Spawner = null;
    [SerializeField] private PointManager PointManager = null;

    [SerializeField] private ParticleSystem ConfettiCanon = null;
    [SerializeField] private TextMeshPro FeedbackTextPrefab = null;

    void Start()
    {
        if (ConfettiCanon == null)
        {
            ConfettiCanon = GameObject.Find("ConfettiCanon").GetComponent<ParticleSystem>();
        }
    }

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

        var feedbackText = Instantiate(FeedbackTextPrefab, transform);

        foreach (var t in Sentences)
        {
            if (t.Sentence + " " == Sentence.text)
            {
                PointManager.AlterPoints(t.PointValue);
                if (t.PointValue > 0)
                {
                    ConfettiCanon.Play();
                    feedbackText.text = "+" + t.PointValue;
                    feedbackText.faceColor = Color.green;
                }
                else
                {
                    feedbackText.text = t.PointValue.ToString();
                    feedbackText.faceColor = Color.red;
                }
                return;
            }
        }

        feedbackText.text = "???";
        Debug.Log("Player got no points, nonsense Sentence");
    }
}
