using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class FirstThrowText : MonoBehaviour
    {

    [ShowInInspector]
    [ReadOnly]
    public List<TMP_Text> firstThrowTexts = new List<TMP_Text>();

    // Start is called before the first frame update
    void Start()
        {
        for (int i = 0; i < 10; i++)
            {
            firstThrowTexts.Add(transform.GetChild(i).transform.GetComponent<TMP_Text>());
        }
        firstThrowTexts[0].SetText("99");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
