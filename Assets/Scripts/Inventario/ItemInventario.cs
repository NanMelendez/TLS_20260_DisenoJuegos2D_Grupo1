using UnityEngine;
[System.Serializable]
public class ItemInventario : MonoBehaviour
{
    public string NombreDeItem;
    public Sprite icono;
    public int cantidad;

    public ItemInventario(string nombre, Sprite Spriteicono, int ctd)
    {
        NombreDeItem = nombre;

        icono = Spriteicono;
        cantidad = ctd;
    }
}
