using UnityEngine;
using UnityEngine.UI;

public class Skill 
{
    public int SkillID = -1;
    public string SkillName = null;
    public string SkillDescription = null;

    public float SkillCooldown = -1;
    public float SkillEffectTime = -1;

    public float SkillShootSpeed = -1;
    public float SkillAutoAimTime = -1;
    public bool SkillAutoAimActive = false;
    public Texture2D SkillEmoji = null;

    public GameObject Projectile = null;
}
