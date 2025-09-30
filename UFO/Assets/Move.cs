using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Vector2 limites = new Vector2(8, 4.5f);
    public float ar = 30f;
    public float sr = 5f;

    void Update()
    {
        Inputs();
    }




    public void Inputs()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoX, movimientoY, 0);

        transform.Translate(movimiento * speed * Time.deltaTime);
        float x = Mathf.Clamp(transform.position.x, -limites.x, limites.x);
        float y = Mathf.Clamp(transform.position.y, -limites.y, limites.y);

        transform.position = new Vector3(x, y, transform.position.z);

        float rZ = -movimientoX * ar;
        Quaternion rotacion = Quaternion.Euler(0, 0, rZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacion, Time.deltaTime * sr);

    }
}
