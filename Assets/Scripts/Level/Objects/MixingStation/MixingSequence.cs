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
    public Animator Fruit1;
    public Animator Fruit2;
    public float SqueezeSpeed;

    [Space(10)]
    public GameObject RumBottle;
    public float PourSpeed;
    public float PourAngle;
    public float TiltSpeed;

    enum MixStates
    {
        SqueezeFruit1,
        SqueezeFruit2,
        OpenChest,
        PourRum,
        Win
    };
    MixStates currentMixState = MixStates.SqueezeFruit1;

    [Space(10)]
    public GameObject[] StateInterfaces;


    // Fruit squeezing progress
    bool fruit1_isSqueezing = false;
    bool fruit2_isSqueezing = false;

    float fruit1Progress;
    float fruit2Progress;
    float pourProgress;

    // Chest opening progress
    Vector2 mousePosStart;
    Vector2 mousePosEnd;

    public void UITurnOn()
    {
        gameObject.SetActive(true);
    }

    public void UITurnOff()
    {
        gameObject.SetActive(false);
    }

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
                    Fruit1.SetTrigger("Unsqueeze");
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
                    Fruit2.SetTrigger("Unsqueeze");
                    currentMixState = MixStates.OpenChest;
                    ChangeUI(2);
                }
                break;

            case MixStates.OpenChest:
                break;

            case MixStates.PourRum:
                if (RumBottle.transform.rotation.z >= PourAngle)
                {
                    pourProgress += PourSpeed;
                }

                if (pourProgress > 1)
                {
                    currentMixState = MixStates.Win;
                    ChangeUI(3);
                }

                break;
        }
    }

    public void Squeeze1True()
    {
        fruit1_isSqueezing = true;
        Fruit1.SetTrigger("Squeeze");
    }

    public void Squeeze1False()
    {
        fruit1_isSqueezing = false;
        Fruit1.SetTrigger("Unsqueeze");
    }

    public void Squeeze2True()
    {
        fruit2_isSqueezing = true;
        Fruit2.SetTrigger("Squeeze");
    }

    public void Squeeze2False()
    {
        fruit2_isSqueezing = false;
        Fruit2.SetTrigger("Unsqueeze");
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
                currentMixState = MixStates.PourRum;
                ChangeUI(3);
            }
        }
    }

    public void TiltRumStart()
    {
        mousePosStart = Mouse.current.position.ReadValue();
    }

    public void TiltRum()
    {
        Vector2 mouse = Mouse.current.position.ReadValue();
        RumBottle.transform.eulerAngles = new Vector3(
            RumBottle.transform.eulerAngles.x,
            RumBottle.transform.eulerAngles.y,
            Mathf.Clamp((mouse.x - mousePosStart.x) * TiltSpeed, -90, 90));
    }
}
