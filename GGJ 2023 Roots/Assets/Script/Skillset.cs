using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillset : MonoBehaviour
{
    public Skill[] skillset;
    void Start()
    {
        skillset = new Skill[4];

        skillset[0] = new Skill();
        skillset[0].SkillID = 0;
        skillset[0].SkillName = "Ivy";
        //skillset[0].S


    }

}
