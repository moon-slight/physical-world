using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour {

    public GameObject option;

	// Use this for initialization
	void Start () {
        option.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void play()
    {
        SceneManager.LoadScene("stage1", LoadSceneMode.Single);
    }

    public void store()
    {
        SceneManager.LoadScene("store", LoadSceneMode.Single);
    }

    public void clickSetting()
    {
        option.SetActive(true);
    }

    public void clickBack()
    {
        option.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
}
