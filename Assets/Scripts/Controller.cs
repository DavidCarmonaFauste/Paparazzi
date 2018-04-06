using UnityEngine;

public class Controller : MonoBehaviour {

	public float moveSpeed = 6;

	Rigidbody2D rb;


	Vector2 velocity;
    
	void Start () {
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
}