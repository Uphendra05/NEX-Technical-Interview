using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public PlayerAbilityUIClass[] playerAbilities;

    public bool canRefresh;
    public float timer;
    public static UIController instance;
    public Animator anim;
    public bool isDescription;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    void Start()
    {
        playerAbilities[0].abilityImage.fillAmount = 0;
        playerAbilities[1].abilityImage.fillAmount = 0;
        playerAbilities[2].abilityImage.fillAmount = 0;



        playerAbilities[0].abilityCooldown = PlayerMovement.instance.dashCooldown;
        playerAbilities[0].isCooldown = PlayerMovement.instance.canDash;


       


       

    }

    
    void Update()
    {

        PlayerAbilityOne();
        PlayerAbilityTwo();
        PlayerAbilityThree();



        if (Input.GetKeyDown(KeyCode.F1))
        {
            isDescription = !isDescription;

            if (isDescription)
            {
                anim.SetBool("IsPressed", true);
            }
            else
            {
                anim.SetBool("IsPressed", false);

            }
        }



    }


    public void PlayerAbilityOne()
    {
        if (Input.GetKeyDown(PlayerMovement.instance.dashKey ) && playerAbilities[0].isCooldown == false)
        {
            playerAbilities[0].isCooldown = true;
            playerAbilities[0].abilityImage.fillAmount = 1;
        }

        if (playerAbilities[0].isCooldown)
        {
            playerAbilities[0].abilityImage.fillAmount -= 1 / playerAbilities[0].abilityCooldown * Time.deltaTime;

            if (playerAbilities[0].abilityImage.fillAmount <= 0)
            {
                playerAbilities[0].abilityImage.fillAmount = 0;
                playerAbilities[0].isCooldown = false;
            }
        }
       
        if(PlayerMovement.instance.canDash == false)
        {
            return;
        }

       

    }

    public void PlayerAbilityTwo()
    {
        if (Input.GetKeyDown(PlayerAbilities.instance.shield) && playerAbilities[1].isCooldown == false)
        {
            playerAbilities[1].isCooldown = true;
            playerAbilities[1].abilityImage.fillAmount = 1;
            StartCoroutine(AbilityLifeOvertime());
        }

        if (playerAbilities[1].isCooldown)
        {
            if(canRefresh)
            {
              playerAbilities[1].abilityImage.fillAmount -= 1 / playerAbilities[1].abilityCooldown * Time.deltaTime;

            }

            if (playerAbilities[1].abilityImage.fillAmount <= 0)
            {
                playerAbilities[1].abilityImage.fillAmount = 0;
                playerAbilities[1].isCooldown = false;
                canRefresh = false;
            }
        }

    }

    public void PlayerAbilityThree()
    {
        if (Input.GetKeyDown(PlayerAbilities.instance.laser) && playerAbilities[2].isCooldown == false)
        {
            playerAbilities[2].isCooldown = true;
            playerAbilities[2].abilityImage.fillAmount = 1;
        }

        if (playerAbilities[2].isCooldown)
        {
            playerAbilities[2].abilityImage.fillAmount -= 1 / playerAbilities[2].abilityCooldown * Time.deltaTime;

            if (playerAbilities[2].abilityImage.fillAmount <= 0)
            {
                playerAbilities[2].abilityImage.fillAmount = 0;
                playerAbilities[2].isCooldown = false;
            }
        }

    }


    IEnumerator AbilityLifeOvertime()
    {
        yield return new WaitForSeconds(timer);
        canRefresh = true;

    }


}



