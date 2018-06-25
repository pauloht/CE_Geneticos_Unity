using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {
    public GameObject obj;
    public Rigidbody rb;
    public Transform tf;

    float xMax = 0;
    float xMin = 0;

    float yMax = 0;
    float yMin = 0;

    float wMax = 0;
    float wMin = 0;

    float x1 = 1f; //mul de hitDistance
    float x2 = 1f; //mul de deg

    float y1 = 1f;
    float y2 = 1f;

    float w1 = 1f;
    float w2 = 1f;

    private float hitDistance = 0;
    private float angle = 0;

    public bool forward = false;
    public bool up = false;
    public bool down = false;

    public bool active = false;

    public float fitness;
	// Use this for initialization
	void Start () {
        //rb.velocity = new Vector3(10, 0, 0); //mover
        //tf.Rotate(Vector3.forward * 45); rotaciona pra cima
    }

    public void setValues(individuo indi) {
        this.x1 = indi.x1;
        this.x2 = indi.x2;
        this.y1 = indi.y1;
        this.y2 = indi.y2;
        this.w1 = indi.w1;
        this.w2 = indi.w2;
    }

    public void setInput()
    {
        float shouldForward = x1 * hitDistance + x2 * angle;
        if (shouldForward <= xMax && shouldForward >= xMin)
        {
            forward = true;
        }
        else
        {
            forward = false;
        }
        float shouldUp = y1 * hitDistance + y2 * angle;
        if (shouldUp <= yMax && shouldForward >= yMin)
        {
            up = true;
        }
        else
        {
            up = false;
        }
        float shouldDown = w1 * hitDistance + w2 * angle;
        if (shouldDown <= wMax && shouldUp >= wMin)
        {
            down = true;
        }
        else
        {
            down = false;
        }
        //double shouldForward = x1*ONOFF + x2*DEG
        //double moveUp = y1*ONOFF + y2*DEG
        //double moveDown = w1*ONOFF + w2*DEG
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active)
        {
            //Debug.Log("start");
            RaycastHit hit;
            if (Physics.Raycast(tf.position, tf.TransformDirection(Vector3.right), out hit))
            {
                Debug.DrawRay(tf.position, tf.TransformDirection(Vector3.right) * hit.distance, Color.red);
                //Debug.Log("Hit");
                hitDistance = hit.distance;
            }
            else
            {
                Debug.DrawRay(tf.position, tf.TransformDirection(Vector3.right) * 10, Color.red);
                //Debug.Log("Miss " + hit.distance);
                hitDistance = 100;
            }
            setInput();
            if (forward)
            {
                rb.velocity = tf.TransformDirection(Vector3.right) * 5;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            if (up)
            {
                tf.Rotate(Vector3.forward * 1); //rotaciona pra cima
            }
            else
            {
                if (down)
                {
                    tf.Rotate(Vector3.forward * -1); //rotaciona pra cima
                }
            }
            //Debug.Log("end");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string hitName = collision.gameObject.name;
        Debug.Log("Colidiu com : " + hitName );
        if (hitName.Equals("asteroide")){
            Debug.Log("Destroying");
            fitness = tf.position.x;
            Destroy(obj);
        }
    }
}
