using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSelection : MonoBehaviour
{
    public static int finalIndex = 0;
    private List<GameObject> models;
    //defualt index of the model
    private int selectionIndex = 0;

    public Animator characterAnimator;
    public AnimationClip[] characterSelectionAnimations;

    // Start is called before the first frame update
    void Start()
    {
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        models[selectionIndex].SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X"), 0.0f));
    }

    private void selectRandomAnimation()
    {
        // Set the trigger to play the animation
        characterAnimator.SetTrigger("StartCharacterSelection");
        Debug.Log("changed");
    }

    public void leftSelect()
    {
        models[selectionIndex].SetActive(false);
        if (selectionIndex == 0)
        {
            selectionIndex = models.Count - 2;
        }
        else
        {
            selectionIndex--;
        }
        finalIndex = selectionIndex;
        models[selectionIndex].SetActive(true);
        selectRandomAnimation();
    }
    public void rightSelect()
    {
        models[selectionIndex].SetActive(false);
        if (selectionIndex == models.Count - 2)
        {
            selectionIndex = 0;
        }
        else
        {
            selectionIndex++;
        }
        finalIndex = selectionIndex;
        models[selectionIndex].SetActive(true);
        selectRandomAnimation();
    }
}
