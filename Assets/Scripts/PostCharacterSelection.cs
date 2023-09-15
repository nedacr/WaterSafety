using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostCharacterSelection : MonoBehaviour
{
    private List<GameObject> models;
    // Start is called before the first frame update
    void Start()
    {
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        models[TestSelection.finalIndex].SetActive(true);
    }

}
