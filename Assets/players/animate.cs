using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    public float frame;
    public float speed;

    public Renderer frameone;
    public Renderer frametwo;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude != 0)
        {
        frame = frame + speed * rb.velocity.magnitude * Time.deltaTime;

        if (frame < 1)
        {
            frameone.enabled = true;
            frametwo.enabled = false;

        }
        if (frame > 1)
        {
            frameone.enabled = false;
            frametwo.enabled = true;

        }
        if (frame > 2)
        {
            frame = 0;

        }

    }
        }
        
}
