using UnityEngine;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;
    float realSpeed;

	Rigidbody2D rb;


	Vector2 velocity;
    
	void Start () {
        realSpeed = moveSpeed;
		rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {

		velocity = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;



    }

    void FixedUpdate() {
		
		rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
        

	}

    public bool CompruebaE()
    {
        if (Input.inputString == "e")
            return true;

        else
            return false;
    }

    public void Stuned()
    {
        moveSpeed = 0;
        Invoke("NoStunned", 1);
    }

    void NoStunned()
    {
        moveSpeed = realSpeed;
    }
}