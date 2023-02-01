using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Animator animator;

    void Start()
    {
        skillCooldownTimer = 0;
        attacked = false;
        attackedSkill = null;
        attackedSkillTimer = 0;
        hasSeed = false;
        speed = Speed;    
        
        animator = GetComponent<Animator>();
    }

    void Update()
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

        Vector3 direction = new Vector3(x_input, 0, y_input).normalized;        
        this.transform.position += direction * speed * Time.deltaTime;

        if (direction.magnitude > 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);

        // Debug.Log(direction * speed * Time.deltaTime);
    }
}
