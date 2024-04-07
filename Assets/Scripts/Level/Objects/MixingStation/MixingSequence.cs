using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MixingSequence : MonoBehaviour
{
    //*---------------------------------------------*
    //
    //  The UI where the player's mouse inputs will be used to trigger cutscenes
    //
    //*---------------------------------------------*

    [Header("Interactive Toggles")]
    public float SqueezeSpeed;

    enum MixStates
    {
        SqueezeFruit1,
        SqueezeFruit2,
        OpenChest,
        PourAlcohol
    };
    MixStates currentMixState = MixStates.SqueezeFruit1;

    [Space(10)]
    public GameObject[] StateInterfaces;

    // Fruit squeezing progress
    bool fruit1_isSqueezing = false;
    bool fruit2_isSqueezing = false;

    float fruit1Progress;
    float fruit2Progress;

    // Chest opening progress
    Vector2 mousePosStart;
    Vector2 mousePosEnd;

    public void ChangeUI(int id)
    {
        for (int i = 0; i < StateInterfaces.Length; i++)
        {
            if (id == i)
            {
                StateInterfaces[i].SetActive(true);
            }
            else
            {
                StateInterfaces[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        switch (currentMixState)
        {
            default:
            case MixStates.SqueezeFruit1:
                if (fruit1_isSqueezing)
                {
                    fruit1Progress += SqueezeSpeed;
                }

                if (fruit1Progress > 1)
                {
                    currentMixState = MixStates.SqueezeFruit2;
                    ChangeUI(1);
                }
                break;

            case MixStates.SqueezeFruit2:
                if (fruit2_isSqueezing)
                {
                    fruit2Progress += SqueezeSpeed;
                }

                if (fruit2Progress > 1)
                {
                    currentMixState = MixStates.OpenChest;
                    ChangeUI(2);
                }
                break;

            case MixStates.OpenChest:
                break;
        }
    }

    public void Squeeze1True()
    {
        fruit1_isSqueezing = true;
    }

    public void Squeeze1False()
    {
        fruit1_isSqueezing = false;
    }

    public void Squeeze2True()
    {
        fruit2_isSqueezing = true;
    }

    public void Squeeze2False()
    {
        fruit2_isSqueezing = false;
    }

    public void OpenChestStart()
    {
        mousePosStart = Mouse.current.position.ReadValue();
    }

    public void OpenChestEnd()
    {
        mousePosEnd = Mouse.current.position.ReadValue();
        if (mousePosStart != Vector2.zero && mousePosEnd != Vector2.zero)
        {
            if (mousePosEnd.y > mousePosStart.y)
            {
                Debug.Log("Chest is being opened");
                currentMixState = MixStates.PourAlcohol;
                ChangeUI(3);
            }
        }
    }
}
