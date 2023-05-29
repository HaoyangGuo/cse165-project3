using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinManager : MonoBehaviour
{
    public GameObject BowlingPin;
    private List<GameObject> currentPins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ResetPins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPins()
    {
        // Destroy old pins
        foreach (GameObject pin in currentPins)
        {
            Destroy(pin);
        }
        currentPins.Clear();

        // Create new pins
        int rowCount = 4;
        float gap = 0.02f;

        float[] offSets = {0f, -0.04f, -0.08f, -0.12f };

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                GameObject newPin = Instantiate(BowlingPin);
                newPin.transform.position = transform.position + new Vector3(offSets[row] + col * (0.06f + gap) , 0f, row * (0.06f + gap));
                currentPins.Add(newPin);
            }
        }
    }

}
