using UnityEngine;

[CreateAssetMenu]
public class BasicRadius : Ability
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject radiusObject;
    [SerializeField]
    private float radius;
    [SerializeField]
    private Vector2 location;
    [SerializeField]
    private float effectDuration;

    public override void Activate(GameObject parent)
    {
        GameObject area = Instantiate(radiusObject, location, Quaternion.identity);
        area.transform.SetParent(parent.transform);
        CircularArea ca = area.GetComponent<CircularArea>();
        ca.Init(damage, activeTime, radius, effectDuration);
    }

    public override void BeginCooldown(GameObject parent)
    {
        // ...
    }
}
