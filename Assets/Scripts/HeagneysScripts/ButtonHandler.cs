using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    // Method to load the next scene
    public void LoadNextScene()
    {
        // Assuming the next scene is the next in the build order
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void OpenCharSelect()
    {
        // Assuming the next scene is the next in the build order
        SceneManager.LoadScene(1);
    }

    public void OpenStory1()
    {
        // Assuming the next scene is the next in the build order
        SceneManager.LoadScene(2);
    }

    public void OpenStory2()
    {
        // Assuming the next scene is the next in the build order
        SceneManager.LoadScene(5);
    }

    public void OpenStory3()
    {
        // Assuming the next scene is the next in the build order
        SceneManager.LoadScene(6);
    }
}
