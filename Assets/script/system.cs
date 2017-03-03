using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour {

    public void clickmenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void clicknext()
    {
        SceneManager.LoadScene("stage1", LoadSceneMode.Additive);
    }

    public void clickrestart()
    {
        SceneManager.LoadScene("stage1", LoadSceneMode.Single);
    }
}
