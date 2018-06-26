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

    private float hitDistance = 0;
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
        Debug.Log("x1V : " + indi.x1);
        v = indi;
    }

    public void setInput()
    {
        float shouldForward = v.x1 * hitDistance + v.x2 * angle;
        if (shouldForward <= xMax && shouldForward >= xMin)
        {
            forward = true;
        }
        else
        {
            forward = false;
        }
        float shouldUp = v.y1 * hitDistance + v.y2 * angle;
        if (shouldUp <= yMax && shouldForward >= yMin)
        {
            up = true;
        }
        else
        {
            up = false;
        }
        float shouldDown = v.w1 * hitDistance + v.w2 * angle;
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
            v.fitness = tf.position.x + 1;
            Destroy(obj);
        }
    }
}
