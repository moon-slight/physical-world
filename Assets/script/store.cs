using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class store : MonoBehaviour {

    public Text points;
    public GameObject warning;

    private int point;

	// Use this for initialization
	void Start () {

        point = 400;

        warning.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        points.text = point.ToString();
	}

    public void buyItem()
    {
        if (point >= 300)
            point -= 300;
        else
            warning.SetActive(true);
    }

    public void backtomenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void cancelButton()
    {
        warning.SetActive(false);
    }
}
