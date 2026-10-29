using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform objetive;
    public float CameraVelocity = 0.025f;
    public Vector3 Travel;

    void Start()
    {
        FindPlayer();
    }

    void LateUpdate()
    {
        // Si por alguna razón el objetivo se perdió, intentamos buscarlo de nuevo
        if (objetive == null)
        {
            FindPlayer();
            return; // Si aún no lo encuentra, no hace nada en este frame para evitar errores
        }

        // Calculamos la posición deseada siguiendo al jugador y respetando el desfase (Travel)
        Vector3 DesiredPosition = objetive.position + Travel;

        // FORZAMOS a que el eje Z siempre sea -10 para que la cámara nunca se aleje ni se meta al mapa
        DesiredPosition.z = -10f;

        // Movimiento suave hacia la posición deseada
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, CameraVelocity);

        transform.position = SmoothedPosition;
    }

    void FindPlayer()
    {
        // Busca automáticamente al jugador por su etiqueta (Tag)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            objetive = player.transform;
        }
    }
}
