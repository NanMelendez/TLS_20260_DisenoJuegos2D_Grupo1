using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float TiempoRestante;
    public bool EstaAvanzando = false;
    public Text TextoTimer;

    private void Start()
    {
        EstaAvanzando=true;
    }

    private void Update()
    {
        if(TiempoRestante > 0)
        {
            TiempoRestante = Time.deltaTime;
            ActualizarTimer(TiempoRestante);
        }
        else
        {
            Debug.Log("Tiempo finalizado");
            TiempoRestante = 0;
            EstaAvanzando = false;
        }
    }
    void ActualizarTimer(float tiempo)
    {
        if(TextoTimer != null)
        {
            int segundos = Mathf.FloorToInt(tiempo % 60);
            int minutos = Mathf.FloorToInt(tiempo/ 60);
            TextoTimer.text = string.Format("{0:00}: {1:00", minutos, segundos);
        }
    }
}

