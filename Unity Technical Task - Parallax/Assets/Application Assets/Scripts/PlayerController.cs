using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;
    bool onGround;
    Rigidbody2D rb;
    Animator anim;
    float jumpCD;
    bool gameStarted;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameManager.gameStarted.AddListener(() =>
        {
            gameStarted = true;
            anim.SetTrigger("start");
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) return;

        if (jumpCD > 0)
            jumpCD -= Time.deltaTime;

        else if (onGround && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector2(0, 40), ForceMode2D.Impulse);
            AudioManager.instance.PlayAudio("jump");
            jumpCD = 0.5f;
        }

        onGround = OnGround(out float groundDistance);
        anim.SetBool("onGround", onGround);
    }

    bool OnGround(out float groundDistance)
    {
        groundDistance = 0;
        Ray2D ray;
        RaycastHit2D hit;
        for (int i = -1; i < 2; i++)
        {
            ray = new Ray2D(transform.position - new Vector3(i, 0), -transform.up);
            hit = Physics2D.Raycast(ray.origin, ray.direction, 0.1f, groundLayer);
            Debug.DrawLine(ray.origin, ray.direction * 0.1f);
            if (hit)
            {
                groundDistance = transform.position.y - hit.point.y;
                return true;
            }
        }
        return false;
    }
}
