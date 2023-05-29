using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchPadManager : MonoBehaviour
{   
    public float speed = 3.0f;
    public float weight = 0.8f;
    public float degree = 0.0f;

    public Text currSpeedText;
    public Text currWeightText;
    public Text currDegreeText;
    
    // Start is called before the first frame update
    void Start()
    {
        currSpeedText.text = speed.ToString("0.00");
        currDegreeText.text = degree.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
