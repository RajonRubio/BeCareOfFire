using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D playerRigidbody2D;

    [Header("目前的水平速度")]
    public float speedX;

    [Header("目前的水平方向")]
    public float horizontalDirection; //數值在 -1~1

    const string HORIZONTAL = "Horizontal";

    [Header("水平推力")]
    [Range(0,150)]
    public float xForce;

    float speedY;

    [Header("最大水平速度")]
    public float maxspeedX = 10.0f;
    public void ControlSpeed()
    {
        speedX = playerRigidbody2D.velocity.x;
        speedY = playerRigidbody2D.velocity.y;
        float newSpeedX = Mathf.Clamp(speedX, -maxspeedX, maxspeedX);
        playerRigidbody2D.velocity = new Vector2(newSpeedX, speedY);
    }

    [Header("垂直向上推力")]
    public float yForce;
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
    void TryJump()
    {
        if (IsGround&&JumpKey)
        {
            playerRigidbody2D.AddForce(Vector2.up*yForce);
        }
    }
    float distance=0.5f;

    [Header("偵測地板的射線起點")]
    public Transform groundCheck;

    [Header("地面圖層")]
    public LayerMask groundLayer;

    public bool grounded;
    //從玩家底部發射一條射線，如果有打到地板圖層的話，代表正踩著地板
    bool IsGround
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);
            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end,groundLayer);
            return grounded;
        }
    }

    void Start () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        maxspeedX = 10.0f;
        yForce = 1300f;

    }
	/// <summary>
    /// 水平移動
    /// </summary>
    void MovementX()
    {
        horizontalDirection = Input.GetAxis(HORIZONTAL);
        playerRigidbody2D.AddForce(new Vector2(xForce*horizontalDirection,0));
    }

	// Update is called once per frame
	void Update () {
        MovementX();
        ControlSpeed();
        TryJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGround&&collision.collider.tag == "FireSite")
        {
            PlayerCllider.HP -= 5;
            print("HP: " + PlayerCllider.HP);
        }
        if (IsGround && collision.collider.tag == "Site")
        {
            PlayerCllider.HP ++;
            print("HP: " + PlayerCllider.HP);
        }
    }
}
