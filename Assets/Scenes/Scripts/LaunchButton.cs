using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchButton : MonoBehaviour
{
    public LaunchPadManager launchPadManager;
    public GameObject bowlingBall;
    
    private Collider sphereCollider;
    
    private List<GameObject> launchedBalls = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "index003.Col")
        {
            LaunchBall();

            sphereCollider.enabled = false;
            StartCoroutine(Cooldown());
        }
    }
    
    IEnumerator Cooldown() {
        yield return new WaitForSeconds(5.0f);
        sphereCollider.enabled = true;
    }

    void LaunchBall()
    {
        // launch a bowling ball to the forward direction of the launchPadManager with speed of launchPadManager.speed
        GameObject newBall = Instantiate(bowlingBall, launchPadManager.transform.position + new Vector3(0.0f, 0.0f, 0.4f), Quaternion.identity);
    
        // Add it to the list of launched balls
        launchedBalls.Add(newBall);
    
        // Ensure the new ball has a Rigidbody component so it can be influenced by forces
        Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
        ballRigidbody.mass = launchPadManager.weight;

        launchPadManager.currWeightText.text = launchPadManager.weight.ToString();

        // Calculate the rotated forward vector
        Vector3 rotatedForward = Quaternion.Euler(0, launchPadManager.degree, 0) * launchPadManager.transform.forward;

        // Add a force to the ball in the direction of the rotated forward vector, multiplied by the desired speed
        ballRigidbody.AddForce(rotatedForward * launchPadManager.speed, ForceMode.VelocityChange);
    }


    public void CleanUpBalls()
    {
        foreach (GameObject ball in launchedBalls)
        {
            Destroy(ball);
        }
        launchedBalls.Clear();
    }
}
