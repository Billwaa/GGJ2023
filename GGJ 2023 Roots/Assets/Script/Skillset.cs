using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillset : MonoBehaviour
{
    public Skill[] skillset = new Skill[5];
    public Texture2D[] skillEmoji = new Texture2D[5];

    public GameObject IvyProjectile;
    public GameObject OnionProjectile;

    void Start()
    {
        // Initialize Skills
        for (int i = 0; i < skillset.Length; i++)
            skillset[i] = new Skill();

        //Skill 0
        skillset[0].SkillID = 0;
        skillset[0].SkillName = "Ivy";
        skillset[0].SkillDescription = "Stun the target";

        skillset[0].SkillCooldown = 5;
        skillset[0].SkillEffectTime = 1;

        skillset[0].SkillShootSpeed = 20;
        skillset[0].SkillAutoAimTime = 5;
        skillset[0].SkillAutoAimActive = true;
        skillset[0].SkillEmoji = skillEmoji[0];
        skillset[0].Projectile = IvyProjectile;
        skillset[0].ProjectileFlightTime = 2;
        skillset[0].SkillDuration = 1;

        //Skill 1
        skillset[1].SkillID = 1;
        skillset[1].SkillName = "Onion";
        skillset[1].SkillDescription = "Cry the target & randonly mixed control";

        skillset[1].SkillCooldown = 4;
        skillset[1].SkillEffectTime = 2;

        skillset[1].SkillShootSpeed = 20;
        skillset[1].SkillAutoAimTime = 5;
        skillset[1].SkillAutoAimActive = true;
        skillset[1].SkillEmoji = skillEmoji[1];
        skillset[1].Projectile = OnionProjectile;
        skillset[1].ProjectileFlightTime = 3;
        skillset[1].SkillDuration = 5f;


        //Skill 2
        skillset[2].SkillID = 2;
        skillset[2].SkillName = "Peanut";
        skillset[2].SkillDescription = "Slow the target";

        skillset[2].SkillCooldown = 8;
        skillset[2].SkillEffectTime = 6;

        skillset[2].SkillShootSpeed = 20;
        skillset[2].SkillAutoAimTime = 5;
        skillset[2].SkillAutoAimActive = true;
        skillset[2].SkillEmoji = skillEmoji[2];
        skillset[2].Projectile = null;

        //Skill 3
        skillset[3].SkillID = 3;
        skillset[3].SkillName = "Chilli";
        skillset[3].SkillDescription = "Speed buff myself";

        skillset[3].SkillCooldown = 5;
        skillset[3].SkillEffectTime = 3;

        skillset[3].SkillShootSpeed = 20;
        skillset[3].SkillAutoAimTime = 0;
        skillset[3].SkillAutoAimActive = false;
        skillset[3].SkillEmoji = skillEmoji[3];
        skillset[3].Projectile = null;

        //Skill 4
        //skillset[4].SkillID = 4;
        //skillset[4].SkillName = "Chilli";
        //skillset[4].SkillDescription = "Speed buff myself";

        //skillset[4].SkillCooldown = 5;
        //skillset[4].SkillEffectTime = 3;

        //skillset[4].SkillShootSpeed = 20;
        //skillset[4].SkillAutoAimTime = 0;
        //skillset[4].SkillAutoAimActive = false;
        //skillset[4].SkillEmoji = skillEmoji[4];
    }

}
