using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;
using TMPro;


public class Score : MonoBehaviour
    {
    [ShowInInspector]
    [ReadOnly]
    public List<TMP_Text> FirstThrowTexts = new List<TMP_Text>();
    [ShowInInspector]
    public GameObject FirstThrowParent;
    [ShowInInspector]
    [ReadOnly]
    public List<TMP_Text> SecondThrowTexts = new List<TMP_Text>();
    [ShowInInspector]
    public GameObject SecondThrowParent;
    [ShowInInspector]
    [ReadOnly]
    public List<TMP_Text> FinalTexts = new List<TMP_Text>();
    [ShowInInspector]
    public GameObject FinalTextParent;

    // Start is called before the first frame update
    void Start()
        {
        for (int i = 0; i < FirstThrowParent.transform.childCount; i++)
            {
            FirstThrowTexts.Add(FirstThrowParent.transform.GetChild(i).GetComponent<TMP_Text>());
            SecondThrowTexts.Add(SecondThrowParent.transform.GetChild(i).GetComponent<TMP_Text>());
            FinalTexts.Add(FinalTextParent.transform.GetChild(i).GetComponent<TMP_Text>());
            }
        }

    // Update is called once per frame
    void Update()
        {

        }
    }