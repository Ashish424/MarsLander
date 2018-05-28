using UnityEngine;
using UnityEngine.SceneManagement;
public static class Utils{





    
    public static void reloadCurrentScene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    
    public static void loadNextScene(){
        int totalScenes = SceneManager.sceneCountInBuildSettings;    
        int index = (SceneManager.GetActiveScene().buildIndex + 1)%totalScenes;
        SceneManager.LoadScene(index,LoadSceneMode.Single);
        
    }

    
    
    
    
    
    
    
    
    
    
    
    
}
