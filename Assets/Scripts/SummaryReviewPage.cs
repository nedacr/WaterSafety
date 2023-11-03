/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryReviewPage : MonoBehaviour
{
    public GameObject SummaryPanel;
    public GameObject ReviewPanel;
    public GameObject LeaderboardPanel;
    public GameObject ScenarioPanel;

    

    public Text Qestion;
    public Text Answer;

    // Start is called before the first frame update
    void Start()
    {
        SummaryPanel.SetActive(false);
        ReviewPanel.SetActive(true);
        LeaderboardPanel.SetActive(false);
        ScenarioPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
       
    }

    private void ClsoeScenario()
    {
        ScenarioPanel.SetActive(false);
    }

    private void OpenScenario()
    {
        ScenarioPanel.SetActive(true);
    }

    private void ToSummary()
    {
        ReviewPanel.SetActive(false);
        SummaryPanel.SetActive(true);
    }
}
*/