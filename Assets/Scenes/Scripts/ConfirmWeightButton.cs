using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmWeightButton : MonoBehaviour
{
    public ChangeWeight changeWeight;
    public LaunchPadManager launchPadManager;
    
    private Collider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "index003.Col")
        {
            {
                string currText = changeWeight.currWeightText.text;
                float parsedWeight;
                if (float.TryParse(currText, out parsedWeight))
                {
                    changeWeight.currWeightText.text = parsedWeight.ToString();
                    launchPadManager.weight = parsedWeight;
                }
                else
                {
                    changeWeight.currWeightText.text = "0.8";
                    launchPadManager.weight = 0.8f;
                }
            }
            
            sphereCollider.enabled = false;
            StartCoroutine(Cooldown());
        }
    }
    
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(1.0f);
        sphereCollider.enabled = true;
    }
}
