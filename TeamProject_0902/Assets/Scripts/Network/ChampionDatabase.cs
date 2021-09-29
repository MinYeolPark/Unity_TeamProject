using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionDatabase : MonoBehaviour
{
<<<<<<< HEAD
    public static ChampionDatabase Instance;

    public Champions currentChampion;
=======
>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6
    public enum Champions
    {
        BaseChamp,
        Xerion,
        BaekRang,
        ColD
    }
<<<<<<< HEAD
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ChampionDescribe(string champName)
    {

    }

=======
>>>>>>> 78e8db30eaf0cddb9bd88a0879750ab762656bb6

}
