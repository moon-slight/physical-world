using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public GameObject player;
    [SerializeField]
    private float xMax = 22.99f;
    [SerializeField]
    private float yMax = 1.78f;
    [SerializeField]
    private float xMin = -21.46f;
    [SerializeField]
    private float yMin = -2.19f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), Mathf.Clamp(player.transform.position.y, yMin, yMax), transform.position.z);
	}
}
