using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteTiger_Stats : MonoBehaviour
{
    //Player Information
    byte AttackAbility;
    byte DefenseAbility;
    byte MagicAbility;
    byte Difficulty;

    //Game Stats
    int HP;             //Health Point
    int HPperLevel;     //HP increasement per Level
    int MP;             //Mana Point
    int MPperLevel;
    int AP;             //Armor Point
    float APperLevel;
    int AD;             //Attack Damage
    float ADperLevel;
    int MRP;             //Magic Resistance Point
    float MRPperLevel;
    float AttackSpeed;
    float AttackSpeedperLevel;
    int MoveSpeed;
    int AttackRange;
    float HPregen;
    float HPregenperLevel;
    int MPregen;
    float MPregenperLevel;

    void Start()
    {
        List<Dictionary<string, object>> data = StatCSVreader.Read("Character_Stats");



        //AttackAbility = (byte)data[1]["infoattack"];    //unboxing porblem?
        AttackAbility = byte.Parse(data[1]["infoattack"].ToString());
        DefenseAbility = byte.Parse(data[1]["infodefense"].ToString());
        MagicAbility = byte.Parse(data[1]["infomagic"].ToString());
        Difficulty = byte.Parse(data[1]["infodifficulty"].ToString());

        HP = int.Parse(data[1]["statshp"].ToString());
        HPperLevel = int.Parse(data[1]["statshpperlevel"].ToString());
        MP = int.Parse(data[1]["statsmp"].ToString());
        MPperLevel = int.Parse(data[1]["statsmpperlevel"].ToString());
        AP = int.Parse(data[1]["statsarmor"].ToString());
        APperLevel = float.Parse(data[1]["statsarmorperlevel"].ToString());
        AD = int.Parse(data[1]["statsattackdamage"].ToString());
        ADperLevel = float.Parse(data[1]["statsattackdamageperlevel"].ToString());
        MRP = int.Parse(data[1]["statsspellblock"].ToString());
        MRPperLevel = float.Parse(data[1]["statsspellblockperlevel"].ToString());
        AttackSpeed = float.Parse(data[1]["statsattackspeed"].ToString());
        AttackSpeedperLevel = float.Parse(data[1]["statsattackspeedperlevel"].ToString());
        MoveSpeed = int.Parse(data[1]["statsmovespeed"].ToString());
        AttackRange = int.Parse(data[1]["statsattackrange"].ToString());
        HPregen = float.Parse(data[1]["statshpregen"].ToString());
        HPregenperLevel = float.Parse(data[1]["statshpregenperlevel"].ToString());
        MPregen = int.Parse(data[1]["statsmpregen"].ToString());
        MPregenperLevel = float.Parse(data[1]["statsmpregenperlevel"].ToString());

    }


    void Update()
    {
        
    }
}
