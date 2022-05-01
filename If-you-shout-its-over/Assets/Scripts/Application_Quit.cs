using UnityEngine;

public class Application_Quit : MonoBehaviour
{
    /*
        function: アプリケーションの終了
    */
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
}
