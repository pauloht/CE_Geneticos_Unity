﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class individuo : IComparable
{
    private static int idCounter = 0;

    public float x1,x2,y1,y2,w1,w2;

    public float fitness = 1f;

    private int id = -1;

    //x = multiplicador de on/off detector
    //y = multiplicador de angulo em deg

    public individuo(individuo copia)
    {
        this.x1 = copia.x1;
        this.x2 = copia.x2;
        this.y1 = copia.y1;
        this.y2 = copia.y2;
        this.w1 = copia.w1;
        this.w2 = copia.w2;

        this.id = idCounter;

        idCounter++;
    }

    public individuo(float x1, float x2, float y1, float y2, float w1, float w2)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.y1 = y1;
        this.y2 = y2;
        this.w1 = w1;
        this.w2 = w2;

        this.id = idCounter;

        idCounter++;
    }

    public individuo(individuo a,individuo b,float percentage)
    {
        float contraPorcentagem = 1 - percentage;
        this.x1 = a.x1 * percentage + b.x1 * contraPorcentagem;
        this.x2 = a.x2 * percentage + b.x2 * contraPorcentagem;
        this.y1 = a.y1 * percentage + b.y1 * contraPorcentagem;
        this.y2 = a.y2 * percentage + b.y2 * contraPorcentagem;
        this.w1 = a.w1 * percentage + b.w1 * contraPorcentagem;
        this.w2 = a.x2 * percentage + b.x2 * contraPorcentagem;

        this.id = idCounter;

        idCounter++;
    }

    override
    public string ToString()
    {
        return ("" + id + "=(" + x1 + ")" + "-> fitness:" + fitness);
    }

    public int CompareTo(object obj)
    {
        if (obj.GetType()==typeof(individuo)){
            individuo y = (individuo)obj;
            if (y.fitness > this.fitness)
            {
                return (-1);
            }else if (y.fitness < this.fitness)
            {
                return (1);
            }
            return (0);
        }else{
            return (0);
        }
    }
}
