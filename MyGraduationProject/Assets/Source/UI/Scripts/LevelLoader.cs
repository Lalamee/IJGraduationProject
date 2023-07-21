using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour, ISceneLoadHandler<int>
{
    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
        
    }

    public void OnSceneLoaded(int argument)
    {
       
    }
}
