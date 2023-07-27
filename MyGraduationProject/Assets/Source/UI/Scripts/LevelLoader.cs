using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour, ISceneLoadHandler<int>
{
    public void LoadLevel()
    {
        int randomLevelNumber = Random.Range(3, 22);
        SceneManager.LoadScene(randomLevelNumber);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnSceneLoaded(int argument)
    {
       
    }
}
