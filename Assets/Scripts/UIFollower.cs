using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollower : MonoBehaviour
{
    public Canvas canvas;
    public GameObject followTarget;//跟踪对象
    public RectTransform textTrasform;
    public Text playerName;
    private float playerHeight;
    public float offset_y;
    // Start is called before the first frame update
    void Start()
    {

        //获取物体高度
        playerHeight = followTarget.GetComponent<SkinnedMeshRenderer>().bounds.size.y;
        playerName = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNamePosition();
    }

    void UpdateNamePosition(){
        Vector3 worldPosition = new Vector3(followTarget.transform.position.x,
        followTarget.transform.position.y + playerHeight + offset_y,followTarget.transform.position.z);
        Vector2 position = Camera.main.WorldToScreenPoint(worldPosition);
        textTrasform.position = position;
    }
}
