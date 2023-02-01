using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Attribute (Player)
    public int PlayerId;
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode AttackKey;
    public KeyCode PassKey;
    public float Speed; // Original Speed

    // Attribute (Attack)
    public Skill Skill;
    public float skillCooldownTimer;

    // Attribute (Got Attack)
    public bool attacked;
    public Skill attackedSkill;
    public float attackedSkillTimer;

    // Attribute (Monkey)
    public bool hasSeed;
    public float speed; // In-Game Speed (including when got skill attacked)
    public bool isDead;
    public SeedController seedController;

    public float passCooldownTimer;
    public Image passCooldown;

    private Animator animator;

    void Start()
    {
        skillCooldownTimer = 0;
        attacked = false;
        attackedSkill = null;
        attackedSkillTimer = 0;
        hasSeed = false;
        speed = Speed;    
        isDead = false;
        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            // Movement Code
            float x_input = 0;
            float y_input = 0;

            if (Input.GetKey(UpKey))
                y_input += 1;
            if (Input.GetKey(DownKey))
                y_input += -1;
            if (Input.GetKey(LeftKey))
                x_input += -1;
            if (Input.GetKey(RightKey))
                x_input += 1;

            if (hasSeed && passCooldownTimer < 0 && Input.GetKey(PassKey))
                seedController.nextTarget();

            Vector3 direction = new Vector3(x_input, 0, y_input).normalized;
            this.transform.position += direction * speed * Time.deltaTime;

            float angle = Mathf.Atan2(-direction.x, -direction.z) * 180.0f / Mathf.PI + 180;
            this.transform.rotation = Quaternion.Euler(0, angle, 0);

            if (direction.magnitude > 0)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);

        }


        if (hasSeed)
        {
            passCooldown.enabled = true;            
            passCooldownTimer -= Time.deltaTime;

            if (passCooldownTimer > 0)
                passCooldown.fillAmount = passCooldownTimer/5.0f;
            else
                passCooldown.fillAmount = 0;

        }
        else
        {
            passCooldown.enabled = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            isDead = true;
            animator.SetBool("isDead", true);
        }
    }
}
