using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour {

    string[] stage = {"stage1", "stage2"};
    int n = 0, total = 2;

    public void clickmenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void clicknext()
    {
        SceneManager.LoadScene(stage[n], LoadSceneMode.Single);
        n = (n+1)%total;
    }

    public void clickrestart()
    {
        SceneManager.LoadScene(stage[n], LoadSceneMode.Single);
    }
}
