using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    [SerializeField] private float shipHealth;
    [SerializeField] private float shipAmmo;
    
    public float getShipHealth(){ return shipHealth;}
    public void setShipHealth(float i){shipHealth = i;}
    public float getShipAmmo() { return shipAmmo;}
    public void setShipAmmo(float i) { shipAmmo = i; }
}
