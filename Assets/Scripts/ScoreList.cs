using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreList : MonoBehaviour
{

    [SerializeField]
    public GameObject highScoreEntryPrefab;
    [SerializeField]
    public Transform highScoreContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScores()
    {
        Debug.Log("ScoreListButton");
        var highScores = HighScoreManager.Instance.GetHighScores();

        foreach (HighScoreEntry highScore in highScores)
        {
            GameObject entryObject = Instantiate(highScoreEntryPrefab, highScoreContainer);
            entryObject.SetActive(true);
            //playerNameText.text = highScore.playerName;
            var textComponents = entryObject.GetComponentsInChildren<Text>();
            Debug.Log(textComponents);

            textComponents[0].text = highScore.playerName.ToString();
            textComponents[1].text = highScore.score.ToString();
        }
        
        float entryHeight = highScoreEntryPrefab.GetComponent<RectTransform>().rect.height;
        float spacing = 10f;

        for (int i = 0; i < highScoreContainer.childCount; i++)
        {
            Transform entry = highScoreContainer.GetChild(i);
            RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
            float yPosition = -i * (entryHeight + spacing);
            entryRectTransform.anchoredPosition = new Vector2(0f, yPosition);
        }
    }
}
