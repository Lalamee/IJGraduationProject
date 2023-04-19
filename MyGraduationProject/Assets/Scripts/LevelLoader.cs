using IJunior.TypedScenes;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private int _levelNumber;
    
    public void LoadMenu()
    {
        _levelNumber = 0;
        LoadLevel(_levelNumber);
    }
    
    public void LoadFirstLevel()
    {
        _levelNumber = 1;
        LoadLevel(_levelNumber);
    }
    
    public void LoadSecondLevel()
    {
        _levelNumber = 2;
        LoadLevel(_levelNumber);
    }
    
    private void LoadLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 0:
                Menu.Load();
                break;
            case 1:
                FirstLevel.Load();
                break;
            case 2:
                SecondLevel.Load();
                break;
        }
    }
}
