using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public BowlingPinManager bowlingPinManager;

    public LaunchButton launchButton;
    
    private Collider sphereCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "index003.Col")
        {
 
            bowlingPinManager.ResetPins();
            launchButton.CleanUpBalls();
  
            sphereCollider.enabled = false;
            StartCoroutine(Cooldown());
        }
    }
    
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(2.0f);
        sphereCollider.enabled = true;
    }
}
