using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {
    public GameObject obj;
    public Rigidbody rb;
    public Transform tf;

    public individuo v;

    float xMax = 50f;
    float xMin = -50f;

    float yMax = 50f;
    float yMin = -50f;

    float wMax = 50f;
    float wMin = -50f;

    private float hitDistance1 = 0;
    private float hitDistance2 = 0;
    private float angle = 0;

    public bool forward = false;
    public bool up = false;
    public bool down = false;

    public bool active = false;
	// Use this for initialization
	void Start () {
        //rb.velocity = new Vector3(10, 0, 0); //mover
        //tf.Rotate(Vector3.forward * 45); rotaciona pra cima
        
    }

    public void setValues(individuo indi) {
        //Debug.Log("x1V : " + indi.x1);
        v = indi;
    }

    public void setInput()
    {
        float shouldForward = v.x1 * hitDistance1 + v.x2*hitDistance2 + v.x3 * angle;
        if (shouldForward <= xMax && shouldForward >= xMin)
        {
            forward = true;
        }
        else
        {
            forward = false;
        }
        float shouldUp = v.y1 * hitDistance1 + v.y2 * hitDistance2 + v.y3 * angle;
        if (shouldUp <= yMax && shouldForward >= yMin)
        {
            up = true;
        }
        else
        {
            up = false;
        }
        float shouldDown = v.w1 * hitDistance1 + v.w2 * hitDistance2 + v.w3 * angle;
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
            RaycastHit hit1;
            RaycastHit hit2;
            Vector3 pos1 = tf.position + tf.TransformDirection(Vector3.up) * tf.localScale.x/2;
            if (Physics.Raycast(pos1, tf.TransformDirection(Vector3.right), out hit1))
            {
                Debug.DrawRay(pos1, tf.TransformDirection(Vector3.right) * hit1.distance, Color.red);
                //Debug.Log("Hit");
                hitDistance1 = hit1.distance;
            }
            else
            {
                Debug.DrawRay(pos1, tf.TransformDirection(Vector3.right) * 10, Color.red);
                //Debug.Log("Miss " + hit.distance);
                hitDistance1 = 100;
            }
            Vector3 pos2 = pos1 - tf.TransformDirection(Vector3.up) * tf.localScale.x;
            if (Physics.Raycast(pos2, tf.TransformDirection(Vector3.right), out hit2))
            {
                Debug.DrawRay(pos2, tf.TransformDirection(Vector3.right) * hit2.distance, Color.red);
                //Debug.Log("Hit");
                hitDistance2 = hit2.distance;
            }
            else
            {
                Debug.DrawRay(pos2, tf.TransformDirection(Vector3.right) * 10, Color.red);
                //Debug.Log("Miss " + hit.distance);
                hitDistance2 = 100;
            }


            setInput();
            if (forward)
            {
                rb.velocity = tf.TransformDirection(Vector3.right) * 20;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            if (up)
            {
                tf.Rotate(Vector3.forward * 1); //rotaciona pra cima
                angle = angle + 1;
            }
            else
            {
                if (down==true)
                {
                    tf.Rotate(Vector3.forward * -1); //rotaciona pra cima
                    angle = angle - 1;
                }
            }
            //Debug.Log("end");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string hitName = collision.gameObject.name;
        v.fitness = Mathf.Pow(tf.position.x,2f) + 1;
        Destroy(obj);
    }
}
