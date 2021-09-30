using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColD_Stats : MonoBehaviour
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



        AttackAbility = byte.Parse(data[2]["infoattack"].ToString());
        DefenseAbility = byte.Parse(data[2]["infodefense"].ToString());
        MagicAbility = byte.Parse(data[2]["infomagic"].ToString());
        Difficulty = byte.Parse(data[2]["infodifficulty"].ToString());

        HP = int.Parse(data[2]["statshp"].ToString());
        HPperLevel = int.Parse(data[2]["statshpperlevel"].ToString());
        MP = int.Parse(data[2]["statsmp"].ToString());
        MPperLevel = int.Parse(data[2]["statsmpperlevel"].ToString());
        AP = int.Parse(data[2]["statsarmor"].ToString());
        APperLevel = float.Parse(data[2]["statsarmorperlevel"].ToString());
        AD = int.Parse(data[2]["statsattackdamage"].ToString());
        ADperLevel = float.Parse(data[2]["statsattackdamageperlevel"].ToString());
        MRP = int.Parse(data[2]["statsspellblock"].ToString());
        MRPperLevel = float.Parse(data[2]["statsspellblockperlevel"].ToString());
        AttackSpeed = float.Parse(data[2]["statsattackspeed"].ToString());
        AttackSpeedperLevel = float.Parse(data[2]["statsattackspeedperlevel"].ToString());
        MoveSpeed = int.Parse(data[2]["statsmovespeed"].ToString());
        AttackRange = int.Parse(data[2]["statsattackrange"].ToString());
        HPregen = float.Parse(data[2]["statshpregen"].ToString());
        HPregenperLevel = float.Parse(data[2]["statshpregenperlevel"].ToString());
        MPregen = int.Parse(data[2]["statsmpregen"].ToString());
        MPregenperLevel = float.Parse(data[2]["statsmpregenperlevel"].ToString());

    }
}
