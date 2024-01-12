using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Renderer myMaterial;

    public void PowerUpPlayer()
    {
        Color myCor = new Color(coloNumberConversion(Random.Range(0,255f)), coloNumberConversion(Random.Range(0,255f)), coloNumberConversion(Random.Range(0,255f)), 1f);
        myMaterial.material.SetColor("_Color", myCor);
    }

    private float coloNumberConversion(float num) 
    {
        return num / 255.0f;
    }
}
