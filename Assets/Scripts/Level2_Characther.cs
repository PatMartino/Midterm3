using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_Characther : MonoBehaviour
{
    public float range;
    public Camera cam;
    public GameObject Wall1;
    public GameObject Read;
    bool wallsetactive = false;
    bool readsetactive = true;

    // Update is called once per frame
    void Update()
    {
        wall();
    }
    void wall()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Wall1"))
        {

            Wall1.SetActive(true);
            wallsetactive = true;
            Read.SetActive(false);
            readsetactive = false;
            Debug.Log("Bum");

        }
        else if (wallsetactive && Input.GetKeyDown(KeyCode.E))
        {
            Wall1.SetActive(false);
            wallsetactive = false;
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Wall1") && !wallsetactive)
        {

            Read.SetActive(true);
            readsetactive = true;


        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("Wall1") && readsetactive)
        {
            Read.SetActive(false);
            readsetactive = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Bum");


        }
    }
}
