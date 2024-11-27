using UnityEngine.SceneManagement;

public class ChangeSceneCommand : ISceneChangerCommand
{
    private string sceneName;

    public ChangeSceneCommand(string sceneName)
    {
        this.sceneName = sceneName;
    }

    public void Execute()
    {
        SceneManager.LoadScene(sceneName);
    }
}
