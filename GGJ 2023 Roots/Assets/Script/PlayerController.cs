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
    public KeyCode UpKey_BK;
    public KeyCode DownKey_BK;
    public KeyCode LeftKey_BK;
    public KeyCode RightKey_BK;
    public KeyCode AttackKey_BK;
    public KeyCode PassKey_BK;
    public float Speed; // Original Speed

    // Attribute (Attack)
    public Skill skill;
    public float skillCooldownTimer;
    public Image skillCooldown;


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

    public float holdTimer = 0;
    public float onionTimer = 0;
    public float chilliTimer = 0;

    public List<PlayerController> playerList;

    private Animator animator;

    public GameObject IvyEffect;
    public GameObject ChilliEffect;

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

        UpKey_BK = UpKey;
        DownKey_BK = DownKey;
        LeftKey_BK = LeftKey;
        RightKey_BK = RightKey;
        AttackKey_BK = AttackKey;
        PassKey_BK = PassKey;
    }

    void Update()
    {
        if (!isDead && holdTimer <= 0)
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


                if (this.skillCooldownTimer > 0)
                {
                    this.skillCooldownTimer -= Time.deltaTime;
                    this.skillCooldown.fillAmount = this.skillCooldownTimer / skill.SkillCooldown;
                }
                else
                {
                    this.skillCooldown.fillAmount = 0;

                    if (Input.GetKey(AttackKey))
                    {
                        if (skill.Projectile != null)
                        {
                            GameObject projectile = GameObject.Instantiate(skill.Projectile, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
                            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
                            projectileController.skill = this.skill;
                            projectileController.playerList = this.playerList;
                            projectileController.ownerId = this.PlayerId;
                            this.skillCooldownTimer = skill.SkillCooldown;
                        }
                        else  // buff
                        {
                            if (this.skill.SkillID == 2)
                            {
                                this.ChilliSkillEffect(skill.SkillEffectTime);
                                this.ChilliEffect.SetActive(true);
                            }

                        this.skillCooldownTimer = skill.SkillCooldown;

                        }

                    }
                }



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



        holdTimer -= Time.deltaTime;
        onionTimer -= Time.deltaTime;
        chilliTimer -= Time.deltaTime;

        if (holdTimer <= 0)
            IvyEffect.SetActive(false);

        if (onionTimer <= 0)
        {
            this.UpKey = this.UpKey_BK;
            this.DownKey = this.DownKey_BK;
            this.LeftKey = this.LeftKey_BK;
            this.RightKey = this.RightKey_BK;   
        }

        if (speed != Speed && chilliTimer <= 0)
        {
            speed = Speed;
            this.ChilliEffect.SetActive(false);
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

    public void IvySkillEffect(float duration)
    {
        Debug.Log("Player " + PlayerId + ": IVY HIT");
        IvyEffect.SetActive(true);
        this.holdTimer = duration;
    }

    public void OnionSkillEffect(float duration)
    {
        Debug.Log("Player " + PlayerId + ": ONION HIT " + duration);
        this.UpKey = this.DownKey_BK;
        this.DownKey = this.UpKey_BK;
        this.RightKey = this.LeftKey_BK;
        this.LeftKey = this.RightKey_BK;
        onionTimer = duration;
    }

    public void ChilliSkillEffect(float duration)
    {
        this.speed = 2 * Speed;
        chilliTimer = duration;
    }
}
