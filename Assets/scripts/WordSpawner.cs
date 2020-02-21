using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordSpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D SpawnBounds = null;

    [SerializeField] private string[] Sentences = null;

    [SerializeField] private TextMeshPro TextPrefab;

    private List<string> WordPile = new List<string>();
    private List<TextMeshPro> Words = new List<TextMeshPro>();
    void Start()
    {
        if(SpawnBounds == null)
        {
            SpawnBounds = GetComponent<BoxCollider2D>();
        }

        foreach(string s in Sentences)
        {
            ParseSentence(s);
        }

        foreach(string s in WordPile)
        {
            Debug.Log("Logged word: " + s);
            TextMeshPro newWord = Instantiate(TextPrefab);
            newWord.text = s;
            //newWord.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        
    }

    private void ParseSentence(string pString)
    {
        List<char> letters = new List<char>();

        int lastSpace = 0;

        for(int i = 0; i < pString.Length; i++)
        {
            if(pString[i] == ' '
                || i == pString.Length)
            {
                string newWord = pString.Substring(lastSpace, i - lastSpace);
                
                WordPile.Add(newWord);
                
                letters.Clear();
                lastSpace = i+1;
            }
            else
            {
                letters.Add(pString[i]);
            }
        }
        string lastWord = pString.Substring(lastSpace, pString.Length - lastSpace);
        WordPile.Add(lastWord);
    }
}
