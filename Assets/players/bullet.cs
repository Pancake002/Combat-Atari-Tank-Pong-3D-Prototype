using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    public Transform v3;
    public float movespeed;
    public Rigidbody rb;
    public bool bulet;
    public move n;
    public Collider col;
    public float hits;

    public float temprot;

    public Quaternion q;

    public Vector3 startpos;

    public Renderer rend;
    public AudioSource shoot;


    public Image ball;

    public AudioSource bounce;

    public pause menuuu;

    public float ypaus;

    public Collider coliderofb;

    // Start is called before the first frame update

    private void Start()
    {
        q = transform.localRotation;
        startpos = transform.localPosition;
    }
    void FixedUpdate()
    {

            Debug.Log(gameObject.name + ":      bulet: " + bulet+ " ball: " + ball.enabled + " rend: " + rend.enabled + " rb.isKinematic: " + rb.isKinematic + " col: " + col.enabled);

        if (bulet == false)
        {
            transform.localPosition = new Vector3(0, -999, 0);



            coliderofb.enabled = false;
            ball.enabled = true;
            rend.enabled = false;
            rb.isKinematic = true;
            col.enabled = false;
            hits = 0;


            if (Input.GetKey(n.controlss[4]))
            {
                transform.localPosition = startpos;

                ball.enabled = false;
                rb.constraints = RigidbodyConstraints.None;

                shoot.Play();
                ypaus = transform.position.y;

                rend.enabled = true;
                coliderofb.enabled = true;

                rb.isKinematic = false;
                transform.localRotation = v3.localRotation;
                col.enabled = true;
                hits = 0;
                bulet = true;
                rb.AddRelativeForce(0, 0, ((movespeed) * Time.deltaTime * -1));
                col.enabled = true;
                StartCoroutine("shootle");



            }


        }

        if(bulet == true)
        {
            transform.position = new Vector3(transform.position.x, ypaus, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            Vector2 direction = collision.GetContact(0).normal;
            if((direction.y == 1)==false)
                {
                hits = hits + 1;
            //bounce.pitch = Random.Range(.0001f, 3);
            bounce.pitch = (hits/2f);
            bounce.Play();
            }

            if (collision.gameObject.name != "grass")
            {

            

            }
           

            Debug.Log(collision.gameObject.name);
            if (hits > 6)
            {                

                 
                StopCoroutine("shootle");
                StartCoroutine("resetbulley");


            }
        }
        
        if (collision.gameObject.tag == "tank")
        {
            if (menuuu.bullethits == true)
            {      
                if(bulet == true)
                {
                    if (coliderofb.enabled != false)
                    {
                        StopCoroutine("shootle");
                        StartCoroutine("resetbulley");
                    }


                }
                

            }
        }
    }
    
    IEnumerator cool()
    {

        yield return new WaitForSeconds(.5f);
        StartCoroutine("resetbulley");

        yield return null;
    }
    IEnumerator shootle()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine("resetbulley");
    }

    IEnumerator resetbulley()
    {
        transform.localPosition = new Vector3(-999, -999, -999);

        yield return new WaitUntil(() => (Input.GetKey(n.controlss[4]) == false));
                rb.constraints = RigidbodyConstraints.FreezePositionY;

        rb.isKinematic = true;
        coliderofb.enabled = false;
        ypaus = .26f;
        rend.enabled = false;
        col.enabled = false;


        yield return new WaitUntil(() => (Input.GetKey(n.controlss[4]) == false));

        transform.localRotation = q;
        rend.enabled = false;


        bulet = false;

        //transform.localPosition = startpos;
        yield return null;

    }

}
