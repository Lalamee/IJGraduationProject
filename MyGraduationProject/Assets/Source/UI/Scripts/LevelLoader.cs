using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour, ISceneLoadHandler<int>
{
    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnSceneLoaded(int argument)
    {
       
    }
}
