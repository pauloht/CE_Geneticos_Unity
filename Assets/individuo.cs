using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individuo : MonoBehaviour {
    public float x1,x2,y1,y2,w1,w2;

    //x = multiplicador de on/off detector
    //y = multiplicador de angulo em deg

    public individuo(float x1,float x2,float y1,float y2,float w1,float w2)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.y1 = y1;
        this.y2 = y2;
        this.w1 = w1;
        this.w2 = w2;
    }
}
