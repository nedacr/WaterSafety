using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryPage : MonoBehaviour
{
    //Panels
    public GameObject SummaryPanel;
    public GameObject ReviewPanel;
    public GameObject LeaderboardPanel;
    public GameObject ScenarioPanel;
    public GameObject NamePanel;

    //buttons
    public Button ToReviewPanel;
    public Button ToLeaderboardPanel;

    // Start is called before the first frame update
    void Start()
    {
        SummaryPanel.SetActive(false);
        ReviewPanel.SetActive(false);
        LeaderboardPanel.SetActive(false);
        ScenarioPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        ToReviewPanel.onClick.AddListener(ActivateReviewPanel);
        ToLeaderboardPanel.onClick.AddListener(ActivateLeaderBoard);
    }

    private void ActivateLeaderBoard()
    {
        SummaryPanel.SetActive(false);
        LeaderboardPanel.SetActive(true);
        NamePanel.SetActive(true);
    }

    private void ActivateReviewPanel()
    {
        SummaryPanel.SetActive(false);
        ReviewPanel.SetActive(true);
        ScenarioPanel.SetActive(false);
    }
}
