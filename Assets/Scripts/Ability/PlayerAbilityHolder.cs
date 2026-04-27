using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityHolder : MonoBehaviour
{
    enum AbilityState
    {
        READY,
        ACTIVE,
        COOLDOWN
    }

    public Ability abilityPrimary;
    public Ability abilitySecondary;

    [SerializeField]
    private InputActionReference attackActionPrimary;
    [SerializeField]
    private InputActionReference attackActionSecondary;

    private AbilityState statePrimary = AbilityState.READY;
    private float cooldownTimePrimary;
    private float activeTimePrimary;
    private AbilityState stateSecondary = AbilityState.READY;
    private float cooldownTimeSecondary;
    private float activeTimeSecondary;

    void Update()
    {
        if (abilityPrimary)
        {
            switch (statePrimary)
            {
                case AbilityState.READY:
                    if (attackActionPrimary.action.IsPressed())
                    {
                        abilityPrimary.Activate(gameObject);
                        statePrimary = AbilityState.ACTIVE;
                        activeTimePrimary = abilityPrimary.activeTime;
                    }
                    break;
                case AbilityState.ACTIVE:
                    if (activeTimePrimary > 0)
                    {
                        activeTimePrimary -= Time.deltaTime;
                    }
                    else
                    {
                        abilityPrimary.BeginCooldown(gameObject);
                        statePrimary =  AbilityState.COOLDOWN;
                        cooldownTimePrimary = abilityPrimary.cooldownTime;
                    }
                    break;
                case AbilityState.COOLDOWN:
                    if (cooldownTimePrimary > 0)
                    {
                        cooldownTimePrimary -= Time.deltaTime;
                    }
                    else
                    {
                        statePrimary = AbilityState.READY;
                    }
                    break;
            }
        }

        if (abilitySecondary)
        {
            switch (stateSecondary)
            {
                case AbilityState.READY:
                    if (attackActionSecondary.action.IsPressed())
                    {
                        abilitySecondary.Activate(gameObject);
                        stateSecondary = AbilityState.ACTIVE;
                        activeTimeSecondary = abilitySecondary.activeTime;
                    }
                    break;
                case AbilityState.ACTIVE:
                    if (activeTimeSecondary > 0)
                    {
                        activeTimeSecondary -= Time.deltaTime;
                    }
                    else
                    {
                        abilitySecondary.BeginCooldown(gameObject);
                        stateSecondary =  AbilityState.COOLDOWN;
                        cooldownTimeSecondary = abilitySecondary.cooldownTime;
                    }
                    break;
                case AbilityState.COOLDOWN:
                    if (cooldownTimeSecondary > 0)
                    {
                        cooldownTimeSecondary -= Time.deltaTime;
                    }
                    else
                    {
                        stateSecondary = AbilityState.READY;
                    }
                    break;
            }
        }
    }
}
