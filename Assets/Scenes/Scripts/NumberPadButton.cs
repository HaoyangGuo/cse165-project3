using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPadButton : MonoBehaviour
{
    public ChangeWeight changeWeight;

    public bool isDel = false;
    public string character;

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

                if (!isDel)
                {
                    changeWeight.currWeightText.text = currText + character;
                }
                else
                {
                    if (currText.Length > 0)
                    {
                        changeWeight.currWeightText.text = currText.Substring(0, currText.Length - 1);
                    }
                }
            }
            
            sphereCollider.enabled = false;
            StartCoroutine(Cooldown());
        }
    }
    
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(2.0f);
        sphereCollider.enabled = true;
    }
}
