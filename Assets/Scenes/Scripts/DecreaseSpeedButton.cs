using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSpeedButton : MonoBehaviour
{
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
            if (launchPadManager.speed > 2.0f)
            {
                launchPadManager.speed -= 0.25f;
                launchPadManager.currSpeedText.text = launchPadManager.speed.ToString("0.00");
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
