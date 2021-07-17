using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public static FightManager fightManager;
    [SerializeField] GameObject canvas;

    int fighters;

    public int totalFighters
    {
        get
        {
            return fighters;
        }
        set
        {
            fighters = value;
        }
    }


    private void Awake()
    {
        fightManager = this;
    }

    public void UpdateFight()
    {
        totalFighters -= 1;

        if (totalFighters > 1)
            return;

        canvas.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
