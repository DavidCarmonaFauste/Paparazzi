using UnityEngine;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;
    float realSpeed;

	Rigidbody2D rb;


	Vector2 velocity;
    
	void Start () {
        realSpeed = moveSpeed;//Guarda la velocidad para cuando se stunee
		rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {

		velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;//Movimiento



    }

    void FixedUpdate() {
		
		rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime); //Movimiento
        

	}

    public bool CompruebaE()//Comprueba si se pulsa la E
    {
        if (Input.inputString == "e")
            return true;

        else
            return false;
    }

    public void Stuned()//Para cuando se stunee al jugador
    {
        moveSpeed = 0;
        Invoke("NoStunned", 1);
    }

    void NoStunned()
    {
        moveSpeed = realSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Guardia"))
            GameManager.instance.Pierde();
    }
}