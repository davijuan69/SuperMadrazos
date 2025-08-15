using UnityEngine;

public class movimiento : MonoBehaviour{
    public float velocidad = 5f;
    public float salto = 5f;
    public bool enSuelo = false;
    private Rigidbody2D rb;
    private float movimientoHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        //float movimientoVertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.W)){
            saltar();
        }
    }

    void FixedUpdate(){
        Vector2 nuevaVelocidad = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
        rb.linearVelocity = nuevaVelocidad;
    }

    void saltar(){
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, salto);
    }
}
