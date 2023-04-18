using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        Menu.Load();
    }
    
    public void LoadFirstLevel()
    {
        _1Level.Load();
    }

    public void LoadSecondLevel()
    {
        _2Level.Load();
    }
}
