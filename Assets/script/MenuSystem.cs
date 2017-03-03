using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void play()
    {
        SceneManager.LoadScene("stage1", LoadSceneMode.Single);
    }
}
