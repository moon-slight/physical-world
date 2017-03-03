using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour{

    public Image shadow;
    public Text t_gameover;
    public Text t_clear;
    public Text t_mention;
    public Button left;
    public Button right;
    public Button jump;
    public Button menu;
    public Button restart;
    public Button nest_stage;

    private bool isable;
    private bool mention;
    private float moveSpeed;                    //移動速度
    private float height;                         //跳躍高度
    private Vector3[] rotate = new Vector3[4];  //固定角色旋轉量
    private int n;                              //旋轉量的選擇
    private Vector3 gravity;                    //重力

	// Use this for initialization
    void Start () {
        left.enabled = true;
        right.enabled = true;
        jump.enabled = true;
        shadow.enabled = false;
        menu.enabled = false;
        menu.image.enabled = false;
        restart.enabled = false;
        restart.image.enabled = false;
        nest_stage.enabled = false;
        nest_stage.image.enabled = false;
        
        isable = true;
        mention = true;
        moveSpeed = 5f; // 玩家移動速度
        height = 7f;
        rotate[0] = transform.rotation.eulerAngles;
        rotate[1] = transform.rotation.eulerAngles;
        rotate[2] = transform.rotation.eulerAngles;
        rotate[3] = transform.rotation.eulerAngles;
        rotate[0] = new Vector3(0, 0, 0);
        rotate[1] = new Vector3(0, 180, 180);
        rotate[2] = new Vector3(0, 180, 0);
        rotate[3] = new Vector3(0, 0, 180);
        gravity = new Vector3(0f, -10f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isable)
        {
            // 左右移動與跳躍
            if (Input.GetKey("a"))
            {
                n = n % 2 + 2;
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime *  Time.timeScale);
            }
            if (Input.GetKey("d"))
            {
                n = (n + 2) % 2;
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime *  Time.timeScale);
            }

            if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.up * height * Time.deltaTime * 1 / Time.timeScale);
            }

            // 重力反轉
            if (Input.GetKeyDown("q") && !mention)
            {
                isable = false;
                gravity.y = -gravity.y;
                Physics.gravity = gravity;
                isable = true;
                n = (n + 1) % 2;
            }
        }

        if (Input.GetKey("z"))
        {
            mention = false;
            shadow.enabled = false;
            t_mention.enabled = false;
            isable = true;
        }

        // 沒按左右時原地停止不動
        if (!Input.GetKey("a") || !Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        }

        // 固定Z軸不動
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        //固定x y z軸的旋轉量
        transform.rotation = Quaternion.Euler(rotate[n]);

	}

    void OnTriggerEnter(Collider trigger)
    {
        // 通關
        if (trigger.gameObject.name == "goal")
        {
            t_clear.enabled = true;
            menu.enabled = true;
            menu.image.enabled = true;
            nest_stage.enabled = true;
            nest_stage.image.enabled = true;
            isable = false;
        }

        // 重力使用的提示
        if (trigger.gameObject.name == "mention" && mention)
        {
            t_mention.enabled = true;
            shadow.enabled = true;
            isable = false;
        }

        // 死亡
        if (trigger.gameObject.name == "down side" || trigger.gameObject.name == "up side")
        {
            t_gameover.enabled = true;
            shadow.enabled = true;
            menu.enabled = true;
            menu.image.enabled = true;
            restart.enabled = true;
            restart.image.enabled = true;
            isable = false;
        }
    }

    public void goleft()
    {
        n = n % 2 + 2;
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * Time.timeScale);
    }

    public void goright()
    {
        n = (n + 2) % 2;
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * Time.timeScale);
    }

    public void jumpup()
    {
        transform.Translate(Vector3.up * height * Time.deltaTime * 1 / Time.timeScale);
    }
}
