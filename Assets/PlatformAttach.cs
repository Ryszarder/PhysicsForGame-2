using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] waypoint;
    int currentWaypointIndex = 0;
    bool playerOn = false;

    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, waypoint[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoint.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        if(playerOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint[0].transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Enter");

            other.transform.parent = transform;

            playerOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Debug.Log("Exit");

            other.transform.parent = null;
            playerOn = false;
        }
    }
}
