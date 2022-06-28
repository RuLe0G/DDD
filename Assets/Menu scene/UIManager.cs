using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject _menuChar;
    public GameObject _menuPodCharK;
    public Button _buttonK;
    public GameObject _menuPodCharM;
    public Button _buttonM;

    public Slider progressVal;
    public Text progressText;
    public Text finLoadText;

    public void MenuCharOpen()
    {
        _menuChar.SetActive(true);
        MenuPodCharKnightShow();
    }
    public void MenuCharClose()
    {
        _menuChar.SetActive(false);
    }
    public void MenuPodCharKnightShow()
    {
        _menuPodCharK.SetActive(true);
        _buttonK.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        _buttonM.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
    }
    public void MenuPodCharKnightHide()
    {
        _menuPodCharK.SetActive(false);
        _buttonK.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        _buttonM.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
    }

    public void MenuPodCharMageShow()
    {
        _menuPodCharM.SetActive(true);
    }
    public void MenuPodCharMageHide()
    {
        _menuPodCharM.SetActive(false);
    }

    public void StartGameKnight()
    {
        StartCoroutine(AsyncLoad(2));
    }
    public void StartGameMage()
    {
        StartCoroutine(AsyncLoad(3));
    }


    public void DebugButton()
    {
        //
    }
    public class LocalDialog
    {
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);
    }
    public void StartMaped()
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.filter = "Уровни\0*.txt";
        openFileName.defExt = "txt";
        if (LocalDialog.GetOpenFileName(openFileName))
        {
            Gloabal.LoadFilePath = openFileName.file;
        }
        StartCoroutine(AsyncLoad(1));
    }
    public void GameQuit() 
    {
        Application.Quit();
    }

    IEnumerator AsyncLoad(int sceneID)
    {
        progressVal.gameObject.SetActive(true);
        progressText.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Single);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            progressVal.value = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            if (operation.progress >= 0.9f && !operation.allowSceneActivation)
            {
                finLoadText.gameObject.SetActive(true);
                progressVal.value = 1.0f;

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }
            
            yield return null;
        }
    }
}
