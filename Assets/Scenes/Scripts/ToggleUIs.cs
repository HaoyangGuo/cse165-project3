using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUIs : MonoBehaviour
{
    public GameObject ChangeWeightUI;
    public GameObject GamePlayUI;

    private int mode = 0;
    
    private Collider sphereCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeWeightUI.SetActive(false);
        GamePlayUI.SetActive(false);
        
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "index003.Col") { 
            if (mode == 0)
            {
                ChangeWeightUI.SetActive(true);
                GamePlayUI.SetActive(false);
                mode += 1;
            } 
            else if (mode == 1)
            {
                ChangeWeightUI.SetActive(false);
                GamePlayUI.SetActive(true);
                mode += 1;
            }
            else if (mode == 2)
            {
                ChangeWeightUI.SetActive(false);
                GamePlayUI.SetActive(false);
                mode = 0;
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
