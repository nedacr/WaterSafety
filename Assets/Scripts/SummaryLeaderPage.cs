using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryLeaderPage : MonoBehaviour
{
    public GameObject SummaryPanel;
    public GameObject ReviewPanel;
    public GameObject LeaderboardPanel;
    public GameObject NamePanel;

    public Button BackToSummary;
    public Button CloseName;
    public Button AddName;

    public Text LeaderboardNames;

    // Start is called before the first frame update
    void Start()
    {
        SummaryPanel.SetActive(false);
        ReviewPanel.SetActive(false);
        LeaderboardPanel.SetActive(true);
        NamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        BackToSummary.onClick.AddListener(ToSummary);
        CloseName.onClick.AddListener(CloseNamePanel);
        AddName.onClick.AddListener(CloseNamePanel);
    }

    private void CloseNamePanel()
    {
        NamePanel.SetActive(false);
    }

    private void ToSummary()
    {
        LeaderboardPanel.SetActive(false);
        SummaryPanel.SetActive(true);
    }
}
