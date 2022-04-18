using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    Animator myAnimator;
    [Header("Ayarlar")]
    public bool canFire;
    float fireSpeed;
    public float fireSpeedPublic;
    public float range;
    [Header("Silah Ayarlari")]
    public int bulletNumber;
    [Header("SESLER")]
    public AudioSource fireAk47;
    [Header("Efektler")]
    public ParticleSystem atesEfeceti;
    public ParticleSystem mermiIzi;
    [Header("Diğer")]
    public Camera cam;


    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canFire && Time.time > fireSpeed && bulletNumber != 0)
            {
                fire();
                fireSpeed = Time.time + fireSpeedPublic;
            }
        }
    }
    void fire()
    {



        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            /*if (hit.transform.gameObject.CompareTag("Dusman"))
            {
                //Instantiate(kanEfekti, hit.point, Quaternion.LookRotation(hit.normal));
                //hit.transform.gameObject.GetComponent<Dusman>().darbeAl(darbeGucu);
            }
            else if (hit.transform.gameObject.CompareTag("Devir"))
            {

                Rigidbody rg = hit.transform.gameObject.GetComponent<Rigidbody>();
                rg.AddForce(-hit.normal * 280f);
                //Instantiate(mermiIzi, hit.point, Quaternion.LookRotation(hit.normal));

            */


            Instantiate(mermiIzi, hit.point, Quaternion.LookRotation(hit.normal));
            myAnimator.Play("fire");
            fireAk47.Play();
            
        }



    }
}


