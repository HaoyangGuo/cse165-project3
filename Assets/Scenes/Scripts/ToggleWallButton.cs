using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWallButton : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    
    private Collider sphereCollider;
    private bool wallEnabled = false;
    
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
            {
                if (wallEnabled)
                {
                    leftWall.SetActive(false);
                    rightWall.SetActive(false);
                    wallEnabled = false;
                }
                else
                {
                    leftWall.SetActive(true);
                    rightWall.SetActive(true);
                    wallEnabled = true;
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
