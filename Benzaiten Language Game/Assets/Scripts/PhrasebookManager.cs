using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhrasebookManager : MonoBehaviour
{
    private DataHolder dataHolder;
    private PhraseBook phrasebook;
    [SerializeField]
    private GameObject phrasePrefab;
    void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        phrasebook = dataHolder.Phrasebook;

        foreach (Phrase phrase in phrasebook.PhraseList)
        {
            GameObject tempPhrase = Instantiate(phrasePrefab, transform);
            TextMeshProUGUI[] textList = tempPhrase.GetComponentsInChildren<TextMeshProUGUI>();

            textList[0].text = phrase.japanese.Replace("~~", dataHolder.player.PlayerName);
            textList[1].text = phrase.english.Replace("~~", dataHolder.player.PlayerName);
        }
    }
}
