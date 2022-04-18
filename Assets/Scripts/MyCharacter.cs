using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyCharacter : MonoBehaviour
{
    //public GameObject ak47;
    //public AudioSource takeWeapon;
    public float range;
    public float range2;
    public Camera cam;
    public GameObject Note1;
    public GameObject Read;
    public GameObject Enter;
   
    bool note1setactive=false;
    bool readsetactive = true;
    bool entersetactive = true;
    
    
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        journal();
        enter();
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AK47"))
        {
            //takeWeapon.Play();
            //ak47.SetActive(true);
            Destroy(other.gameObject);


        }
    }
    
    
    void journal()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Journal"))
        {

            Note1.SetActive(true);
            note1setactive = true;
            Read.SetActive(false);
            readsetactive = false;
            Debug.Log("Bum");

        }
        else if (note1setactive && Input.GetKeyDown(KeyCode.E))
        {
            Note1.SetActive(false);
            note1setactive = false;
        }

        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && hit.transform.gameObject.CompareTag("Journal") && !note1setactive)
        {

            Read.SetActive(true);
            readsetactive = true;


        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && !hit.transform.gameObject.CompareTag("Journal") && readsetactive)
        {
            Read.SetActive(false);
            readsetactive = false;
        }
    }
    void enter()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range2) && hit.transform.gameObject.CompareTag("Pyramid"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Enter.SetActive(false);
            entersetactive = false;
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range2) && hit.transform.gameObject.CompareTag("Pyramid") && !readsetactive)
        {

            Enter.SetActive(true);
            entersetactive = true;
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range2) && !hit.transform.gameObject.CompareTag("Pyramid") && readsetactive)
        {
            Enter.SetActive(false);
            entersetactive = false;
        }
    }
}
