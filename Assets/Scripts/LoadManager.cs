using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadManager : MonoBehaviour
{
    public PlacableObject[] placedObjects;
    string JSON;
    public GameObject[] prefabs;
    public GameObject parentObject;

    private void Start() {
        int itsFromLoad = PlayerPrefs.GetInt("Loaded");

        if(itsFromLoad == 1){
           ReadJSON();
           GetObjectsFromSaveFile();
           PlaceObjects();
        }
    }


    void ReadJSON(){
        JSON = File.ReadAllText (Application.persistentDataPath + "/saves/" + PlayerPrefs.GetString("fileName"));
    }
    void GetObjectsFromSaveFile(){
        placedObjects = JsonHelper.FromJson<PlacableObject>(JSON);
    }

    void PlaceObjects(){

        foreach(var item in placedObjects){

         GameObject gameObj;
            switch(item.Type){
                case "Cube":
                    gameObj = Instantiate(prefabs[0], parentObject.transform);
                    SetUpObject(gameObj,item);
                    break;
                case "Cylinder":
                    gameObj = Instantiate(prefabs[1], parentObject.transform);
                    SetUpObject(gameObj,item);
                    break;
                case "Sphere":
                    gameObj = Instantiate(prefabs[2], parentObject.transform);
                    SetUpObject(gameObj,item);
                    break;
                default:
                    break;
            }
        }
    }

    void SetUpObject(GameObject obj,PlacableObject data){
        obj.transform.localPosition = data.Coordinates;
        var objRendered = obj.GetComponent<Renderer>();
        Color customColor = new Color((float)data.Color.R,(float)data.Color.G,(float)data.Color.B);
        objRendered.material.SetColor("_Color", customColor);
    }

}
