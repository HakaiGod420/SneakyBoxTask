using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{


    public GameObject MainMenuButtons;
    public GameObject LoadLevelMenu;
    public GameObject ParentFileContent;
    public GameObject ButtonPrefab;
    public List<string> fileNames = new List<string>();


    void Start(){
        Time.timeScale = 1f;
    }
    public void NewGame(){
        PlayerPrefs.SetInt("Loaded", 0);
        SceneManager.LoadScene("MainGameScene");
    }

    public void LoadScene(string fileName){
        PlayerPrefs.SetString("fileName", fileName);
        PlayerPrefs.SetInt("Loaded", 1);
        SceneManager.LoadScene("MainGameScene");
    }

    public void OpenLoadMenu(){
        GetFileNames();
        SpawnButtons();
        LoadLevelMenu.SetActive(true);
        MainMenuButtons.SetActive(false);
    }

    public void ExitGame(){
         Application.Quit();
    }

    public void BackToMenu(){
        LoadLevelMenu.SetActive(false);
        MainMenuButtons.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }

    void GetFileNames(){
        System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        DirectoryInfo d = new DirectoryInfo(Application.persistentDataPath + "/saves/");

        FileInfo[] Files = d.GetFiles("*.dat");

        foreach(FileInfo file in Files )
        {
            fileNames.Add(file.Name);
        }
    }

    void SpawnButtons(){
        for(var i = 0; i < fileNames.Count;i++){
            string fileName = fileNames[i];
            GameObject filePrefabLvl = Instantiate(ButtonPrefab, ParentFileContent.transform);
            filePrefabLvl.transform.GetChild(0).GetComponent<TMP_Text>().text = fileNames[i];
            filePrefabLvl.GetComponent<Button>().onClick.AddListener(() => LoadScene(fileName));
      }
    }


}
