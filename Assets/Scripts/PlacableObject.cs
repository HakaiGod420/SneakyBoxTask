using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


[System.Serializable]
public class PlacableObject 
{
    public Vector3 Coordinates;
    public ObjectColor Color;
    public string Type;

    public PlacableObject(Vector3 coord,ObjectColor cl, string type){
        this.Coordinates = coord;
        this.Color = cl;
        this.Type = type;
    }
    public PlacableObject(Vector3 coord, string type){
        this.Coordinates = coord;
        this.Color = new ObjectColor(0,0,0);
        this.Type = type;
    }
}
