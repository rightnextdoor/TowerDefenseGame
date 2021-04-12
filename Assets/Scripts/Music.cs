using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{

    AudioManager audioManager;

   private void Start()
    {
        audioManager = AudioManager.instance;

        Debug.Log("play music");
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
       // SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            //audioManager.StopMusic();
            //audioManager.Play("MenuTheme");
            Debug.Log("play menu theme");
        }
        else if (scene.buildIndex == 2) {
            //audioManager.StopMusic();
            //audioManager.Play("Level01Theme");
            Debug.Log("Play level 01");
        }

        //switch (scene.buildIndex)
        //{
        //    case 0:
        //        Debug.Log("play menu theme");
        //        audioManager.Play("MenuTheme");
        //        break;
        //    case 2:
        //        Debug.Log("Play level 01");
        //        audioManager.Play("Level01Theme");
        //        break;
        //    default:
        //        Debug.Log("continue playing current music");
                
        //        break;
        //}
        
    }
}
