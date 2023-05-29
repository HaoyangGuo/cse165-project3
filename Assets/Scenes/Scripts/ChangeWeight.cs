using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeight : MonoBehaviour
{
    public Text currWeightText;

    // Start is called before the first frame update
    void Awake()
    {
        currWeightText.text = "0.8";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
