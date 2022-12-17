#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneOpen : MonoBehaviour
{
    private const string BASE_SCENE_PATH = "Assets/Scenes/";

    [MenuItem("OpenScene/1. Preloader #1")]
    private static void OpenPreloader()
    {
        if (Application.isPlaying)
            return;

        OpenScene("preloader", BASE_SCENE_PATH);
    }

    [MenuItem("OpenScene/3. Lobby #2")]
    public static void OpenLobby()
    {
        if (Application.isPlaying)
            return;
        OpenScene("Lobby", BASE_SCENE_PATH);
    }
    
    private static void OpenScene(string sceneName, string path)
    {
        var unity = ".unity";
        EditorSceneManager.OpenScene(path + sceneName + unity);
    }
}
#endif