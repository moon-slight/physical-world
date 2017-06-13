using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour {

    public Image shadow;
    public Text guide;
    public Text t_gameover;
    public Text t_clear;
    public Text timer;
    public Button menu;
    public Button restart;
    public Button nest_stage;
    public GameObject list;

    private float start_time;
    private bool stop_time;

    string[] stage = {"stage1", "stage2"};
    int n = 0, total = 2;

    void Start()
    {
        shadow.enabled = true;
        guide.enabled = true;
        menu.enabled = false;
        menu.image.enabled = false;
        restart.enabled = false;
        restart.image.enabled = false;
        nest_stage.enabled = false;
        nest_stage.image.enabled = false;
        list.SetActive(false);
  
        start_time = Time.time;
        stop_time = true;
    }

    void Update()
    {
        if (!stop_time && shadow.enabled == false)
        {
            float t = Time.time - start_time;
            string min = ((int)t / 60).ToString("d2");
            string sec = (t % 60).ToString("f3");

            timer.text = min + ":" + sec;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            list.SetActive(true);
            stop_time = true;
        }

        if(Input.GetKey("z"))
        {
            shadow.enabled = false;
            guide.enabled = false;
            stop_time = false;
        }
    }

    public void backtomenu()
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

    public void clickresume()
    {
        list.SetActive(false);
        stop_time = false;
    }

    void OnTriggerEnter(Collider trigger)
    {
        switch (trigger.gameObject.name)
        {
            case "goal": // 通關
                t_clear.enabled = true;
                menu.enabled = true;
                menu.image.enabled = true;
                nest_stage.enabled = true;
                nest_stage.image.enabled = true;
                stop_time = true;
                break;

            case "down side": //死亡
            case "up side":
                t_gameover.enabled = true;
                shadow.enabled = true;
                menu.enabled = true;
                menu.image.enabled = true;
                restart.enabled = true;
                restart.image.enabled = true;
                stop_time = true;
                break;
        }

    }
}
