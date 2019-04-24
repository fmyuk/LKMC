using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class SampleAnimation : MonoBehaviour
{

    // Animator コンポーネント
    private Animator animator;

    // 設定したフラグの名前
    private const string key_isRun = "IsRun";
    private const string key_isAttack01 = "IsAttack01";
    private const string key_isAttack02 = "IsAttack02";
    private const string key_isJump = "IsJump";
    private const string key_isDamage = "IsDamage";
    private const string key_isDead = "IsDead";

    private Animator Reload;
    [SerializeField]
    private Animator gunAnim;

    public int hp;
    private GameObject gameoverText;

    private int bestScore;
    public Text bestKill;

    public Point pt;
    public int score;
    public GameObject finishUI;
    // 初期化メソッド
    void Start()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
        animator.SetBool("isDamage", false);
        this.gameoverText = GameObject.Find("GameOverText");
        hp = 1000;

        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            bestScore = 0;
        }
    }

    // 1フレームに1回コールされる
    void Update()
    {
        float dx = CrossPlatformInputManager.GetAxis("Horizontal");
        float dz = CrossPlatformInputManager.GetAxis("Vertical");
        transform.Translate((float)(dx * 0.15), 0, (float)(dz * 0.15));

        animator.SetBool("isDamage", false);

        // 矢印上ボタンを押下している
        if (Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W)) || dx != 0 || dz != 0)
        {
            // IdleからRunに遷移する
            this.animator.SetBool(key_isRun, true);
        }
        //else
        //{ 
        //    // RunからIdleに遷移する
        //    this.animator.SetBool(key_isRun, false);
        //}
        if(dx == 0 && dz == 0)
        {
            this.animator.SetBool(key_isRun, false);
        }

        if (CrossPlatformInputManager.GetButton("Jump"))
        {
            gunAnim.SetBool("WaitShot", true);
        }
        else
        {
            gunAnim.SetBool("WaitShot", false);
        }

        // ジャンプ spaceを押す
        if (Input.GetKeyUp("space"))
        {
            //Jumpに遷移する
            this.animator.SetBool(key_isJump, true);
        }
        else
        {
            // JumpからIdleに遷移する
            this.animator.SetBool(key_isJump, false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || CrossPlatformInputManager.GetButtonDown("Reload"))
        {
            this.animator.SetTrigger("Reload");
        }

        score = pt.kill;

        if (bestScore < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        if (hp <= 0)
        {
            finishUI.SetActive(true);
            animator.SetBool("IsDead", true);
            animator.SetBool("IsDamage", false);


            bestKill.text = "Best Kill = " + bestScore;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hp -= 100;
            animator.SetBool("IsDamage", true);
        }
        if (collision.gameObject.tag == "Base")
        {
            hp -= 1000;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("IsDamage", false);
        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}