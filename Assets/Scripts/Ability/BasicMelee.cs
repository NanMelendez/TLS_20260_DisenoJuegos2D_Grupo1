using UnityEngine;

[CreateAssetMenu]
public class BasicMelee : Ability
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject meleeRange;
    [SerializeField]
    private Vector2 offset;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();

        float angle = Mathf.Atan2(movement.LastDirection.y, movement.LastDirection.x);
        Vector2 rotatedOffset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * offset.magnitude;

        GameObject area = Instantiate(meleeRange, parent.transform.position + (Vector3)rotatedOffset, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg + 90));
        area.transform.SetParent(parent.transform);
        MeleeArea ma = area.GetComponent<MeleeArea>();
        ma.Init(damage, activeTime);
    }

    public override void BeginCooldown(GameObject parent)
    {
        // ...
    }
}
