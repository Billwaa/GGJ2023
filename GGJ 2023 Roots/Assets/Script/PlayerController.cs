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

    // Timer
    public float holdTimer = 0;
    public float onionTimer = 0;
    public float chilliTimer = 0;
    public float fartTier = 0;

    public List<PlayerController> playerList;

    private Animator animator;

    // Skill Affected
    public GameObject IvyEffect;
    public GameObject ChilliEffect;
    public GameObject OnionEffect;
    public GameObject FartEffect;

    // Prefab
    public GameObject FartBomb;
    public GameObject fartedObj = null;

    // Rigidbody
    public Rigidbody rb;
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
        rb = GetComponent<Rigidbody>();

        UpKey_BK = UpKey;
        DownKey_BK = DownKey;
        LeftKey_BK = LeftKey;
        RightKey_BK = RightKey;
        AttackKey_BK = AttackKey;
        PassKey_BK = PassKey;
    }

    void Update()
    {
        if (!isDead)
        {
            if (hasSeed && passCooldownTimer < 0 && Input.GetKey(PassKey))
                seedController.nextTarget();

            if (holdTimer <= 0)
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
                            if (this.skill.SkillID == 3)
                            {
                                this.ChilliSkillEffect(skill.SkillEffectTime);
                                this.ChilliEffect.SetActive(true);
                            }

                            else if (this.skill.SkillID == 2)
                            {
                                GameObject fartBomb = GameObject.Instantiate(FartBomb, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 0, 0));
                                FartBombController fartBombController = FartBomb.GetComponent<FartBombController>();
                                fartBombController.effectTimer = this.skill.SkillEffectTime;
                                fartBombController.ownerID = this.PlayerId;
                            }

                            this.skillCooldownTimer = skill.SkillCooldown;

                        }

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
            OnionEffect.SetActive(false);
        }

        if (speed != Speed && chilliTimer <= 0)
        {
            if (!FartEffect.activeSelf || !fartedObj)
            {
                speed = Speed;
                FartEffect.SetActive(false);
            }
            this.ChilliEffect.SetActive(false);
        }

        // Check if farted object is still around, if not reset speed
        //if (!fartedObj)
        //{
        //    fartedObj = null;
        //    speed = Speed;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            isDead = true;
            animator.SetBool("isDead", true);
        }

        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fart")
        {
            if (other.gameObject.GetComponent<FartBombController>().ownerID != this.PlayerId)
            {
                FartEffect.SetActive(true);
                this.speed = 0.4f * Speed;
                fartedObj = other.gameObject;
            }
        }
    }


    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Fart")
        {
            this.speed = Speed;
            FartEffect?.SetActive(false);
        }
    }

    public void IvySkillEffect(float duration)
    {
        Debug.Log("Player " + PlayerId + ": IVY HIT");
        IvyEffect.SetActive(true);
        this.holdTimer = duration;
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void OnionSkillEffect(float duration)
    {
        Debug.Log("Player " + PlayerId + ": ONION HIT " + duration);
        this.UpKey = this.DownKey_BK;
        this.DownKey = this.UpKey_BK;
        this.RightKey = this.LeftKey_BK;
        this.LeftKey = this.RightKey_BK;
        onionTimer = duration;
        OnionEffect.SetActive(true);
    }

    public void ChilliSkillEffect(float duration)
    {
        this.speed = 2 * Speed;
        chilliTimer = duration;
    }
}
