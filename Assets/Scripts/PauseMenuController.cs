using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using TMPro;



public class PauseMenuController : MonoBehaviour
{

    string FileName = "Room1";
    public GameObject objectsParrent;
    public PlacableObject[] placedObjects;
    public TMP_InputField FileInputName;
    
    public void Resume(){

    }
    public void NewScene(){
        PlayerPrefs.SetInt("Loaded", 0);
        SceneManager.LoadScene("MainGameScene");
        Time.timeScale = 1f;
    }
    public void SaveScene(){
        placedObjects = new PlacableObject[objectsParrent.transform.childCount];

        for(int i = 0; i < objectsParrent.transform.childCount;i++){
            GameObject gameObject = objectsParrent.transform.GetChild(i).gameObject;
            PlacableObject objectData  = GetData(gameObject);
            placedObjects[i] = objectData;
        }
        string json = JsonHelper.ToJson(placedObjects, true);
        //Debug.Log(json);
        SaveFile(json);
    }
    public void QuitToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    PlacableObject GetData(GameObject obj){
        Renderer renderer = obj.GetComponent<Renderer>();
        Color color = renderer.material.color;
        string objType = obj.GetComponent<ObjectInfo>().Type;

        ObjectColor selectedCollor = new ObjectColor(color.r, color.g, color.b);
        return new PlacableObject(obj.transform.localPosition,selectedCollor,objType);

    }

    void SaveFile(string json){
         // Encode the string as a byte array
        byte[] encodedData = Encoding.UTF8.GetBytes(json);

        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/saves/");

        // Get the path to the persistent data directory
        string filePath = Application.persistentDataPath + "/saves/"+FileName+".dat";
        // Write the encoded data to the file
        File.WriteAllBytes(filePath, encodedData);
    }

    public void ChangeName(){
        FileName  = FileInputName.text;
    }

    
}
