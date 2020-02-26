using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Direction
{
    NORTH,
    EAST,
    SOUTH,
    WEST
}

[System.Serializable]
public class SentenceWrapper
{
    [SerializeField] public string Sentence;
    [SerializeField] public int PointValue;
}

public class WordSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] SpawnZones = null;

    [SerializeField] private SentenceWrapper[] Sentences = null;

    [SerializeField] private TextMeshPro TextPrefab = null;

    [SerializeField] private float SpawnDelay = 0.5f;

    private float SpawnTimer = 0;


    private List<string> WordPile = new List<string>();

    void Start()
    {
        foreach (SentenceWrapper s in Sentences)
        {
            ParseSentence(s.Sentence);
        }

        //foreach(string s in WordPile)
        //{
        //    Debug.Log("Logged word: " + s);
        //    TextMeshPro newWord = Instantiate(TextPrefab);
        //    newWord.text = s;
        //}

    }

    void Update()
    {
        SpawnTimer -= Time.deltaTime;

        if (SpawnTimer <= 0)
        {
            SpawnWord();
        }
    }

    private void SpawnWord()
    {
        Direction randomDirection = (Direction) Random.Range(0, 4);

        Vector3 spawnPos;

        spawnPos.x = Random.Range(SpawnZones[(int) randomDirection].bounds.min.x,
            SpawnZones[(int) randomDirection].bounds.max.x);
        spawnPos.y = Random.Range(SpawnZones[(int) randomDirection].bounds.min.y,
            SpawnZones[(int) randomDirection].bounds.max.y);

        spawnPos.z = transform.position.z;

        TextMeshPro newWord = Instantiate(TextPrefab, spawnPos, Quaternion.identity);
        newWord.GetComponent<Word>().SetDirection(randomDirection);
        newWord.text = WordPile[Random.Range(0, WordPile.Count)];

        SpawnTimer = SpawnDelay;
    }

    private void ParseSentence(string pString)
    {
        List<char> letters = new List<char>();

        int lastSpace = 0;

        for (int i = 0; i < pString.Length; i++)
        {
            if (pString[i] == ' '
                || i == pString.Length)
            {
                string newWord = pString.Substring(lastSpace, i - lastSpace);

                WordPile.Add(newWord);

                letters.Clear();
                lastSpace = i + 1;
            }
            else
            {
                letters.Add(pString[i]);
            }
        }

        string lastWord = pString.Substring(lastSpace, pString.Length - lastSpace);
        WordPile.Add(lastWord);
    }

    public SentenceWrapper[] GetSentences()
    {
        return Sentences;
    }

}
