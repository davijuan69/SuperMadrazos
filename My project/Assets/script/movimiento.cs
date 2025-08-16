using UnityEngine;

public class movimiento : MonoBehaviour{
    public float velocidad = 5f;
    public float salto = 6f;
    public bool enSuelo = false;
    private Rigidbody2D rb;
    private float movimientoHorizontal;
    public float distanciaRaycast = 1.2f;
    public LayerMask capaSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        //float movimientoVertical = Input.GetAxis("Vertical");

        DetectarSuelo();

        //if(enSuelo) {
        //Debug.Log("Está en el suelo");
        //} else {
        //Debug.Log("NO está en el suelo");
        //}

        if(Input.GetKeyDown(KeyCode.W) && enSuelo){
            saltar();
        }
    }

    void FixedUpdate(){
        Vector2 nuevaVelocidad = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
        rb.linearVelocity = nuevaVelocidad;
    }

    void DetectarSuelo(){
    // Posición del personaje
    Vector2 posicion = transform.position;
     posicion.y -= 0.5f;
    
    // Dispara raycast hacia abajo
    RaycastHit2D hit = Physics2D.Raycast(posicion, Vector2.down, distanciaRaycast, capaSuelo);
    
    // Si toca algo, está en el suelo
    enSuelo = hit.collider != null;
    }

    void saltar(){
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, salto);
    }
}
