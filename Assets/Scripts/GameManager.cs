using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class GameManager : MonoBehaviour
{
    public bool SpawnObjectUIActive = false;
    private GameObject tempGameObject;
    public bool GameObjectMenuUI = false;
    public bool PauseMenuUIActive = false;
    public bool GameObjectMenu = false;
    public bool SaveFileUI = false;
    public GameObject ObjectSpawnMenu;
    public GameObject GameObjectEditMenu;
    public GameObject SaveFileMenu;
    public GameObject ParentSpawnObject;
    public GameObject PauseMenu;
    

    public GameObject[] prefabs;

    void Update(){

        if (Input.GetKeyDown(KeyCode.R) && GameObjectMenuUI == false && SaveFileUI == false)
        {
            if (SpawnObjectUIActive == true || PauseMenuUIActive == true)
            {
                ObjectSpawnMenu.SetActive(false);
                SpawnObjectUIActive = false;
                Time.timeScale = 1f;
            }
            else{
                ObjectSpawnMenu.SetActive(true);
                SpawnObjectUIActive = true;
                Time.timeScale  = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameObjectMenuUI == false && SpawnObjectUIActive == false && SaveFileUI == false)
        {
            if (PauseMenuUIActive == true )
            {
                Time.timeScale  = 1f;
                PauseMenu.SetActive(false);
                PauseMenuUIActive = false;
            }
            else{
                Time.timeScale  = 0f;
                PauseMenu.SetActive(true);
                PauseMenuUIActive = true;
            }
        }
    }



    public void SpawnCube()
    {
        GameObject pointPrefab = Instantiate(prefabs[0], ParentSpawnObject.transform);
    }

    public void SpawnSphere()
    {
        GameObject pointPrefab = Instantiate(prefabs[1], ParentSpawnObject.transform);
    }

    public void SpawnCylinder()
    {
        GameObject pointPrefab = Instantiate(prefabs[2], ParentSpawnObject.transform);
    }

    public void CloseObjectMenu()
    {
        GameObjectEditMenu.SetActive(false);
        GameObjectMenuUI = false;
        tempGameObject = null;
        Time.timeScale = 1f;
    }

    public void OpenObjectMenu(GameObject gm)
    {
        if (SpawnObjectUIActive == false)
        {
            Time.timeScale = 0f;
            GameObjectEditMenu.SetActive(true);
            GameObjectMenuUI = true;
            tempGameObject = gm;
        }   
    }

    public void DestroyGameObject()
    {
        Destroy(tempGameObject);
        CloseObjectMenu();
    }

    public void ChangeColor(string collorCode)
    {
        var objRendered = tempGameObject.GetComponent<Renderer>();
        Color customColor = ConvertHEXToRGB(collorCode);
        objRendered.material.SetColor("_Color", customColor);
    }

    private Color ConvertHEXToRGB(string collorCode)
    {
        int red = 0;
        int green = 0;
        int blue = 0;

        if (collorCode.Length == 6)
        {
            //#RRGGBB
            red = int.Parse(collorCode.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            green = int.Parse(collorCode.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            blue = int.Parse(collorCode.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        }
        else if (collorCode.Length == 3)
        {
            //#RGB
            red = int.Parse(collorCode[0].ToString() + collorCode[0].ToString(), NumberStyles.AllowHexSpecifier);
            green = int.Parse(collorCode[1].ToString() + collorCode[1].ToString(), NumberStyles.AllowHexSpecifier);
            blue = int.Parse(collorCode[2].ToString() + collorCode[2].ToString(), NumberStyles.AllowHexSpecifier);
        }
       
        return new Color((float)red/255.0f, (float)green/255.0f, (float)blue/255.0f,1f);
    }

    public void OpenSaveFileMenu(){
        PauseMenu.SetActive(false);
        SaveFileMenu.SetActive(true);
        SaveFileUI = true;
    }

    public void CloseSaveUI(){
        PauseMenu.SetActive(true);
        SaveFileMenu.SetActive(false);
        SaveFileUI = false;
    }

    public void CloseSpawnMenu(){
        ObjectSpawnMenu.SetActive(false);
        SpawnObjectUIActive = false;
        Time.timeScale = 1f;
    }


}
