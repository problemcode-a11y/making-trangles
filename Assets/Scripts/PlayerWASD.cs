using UnityEngine;

public class PlayerWASD : MonoBehaviour
{
    //for a basic WASD we'll need speed, and movement keys
    public float speed;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;

    //we also need the transform of the player
    //this is data that is accesible from inside : MonoBehaviour
    Transform pT; //we can declare it as pT just to show how it works
    PlayerWASD myScript; //we can also declare our own script here
    Rigidbody myRB;

    //JUMP VARS
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    void Start()
    {
        //this is a keyword that describes the space or scope of the script itself
        myScript = this;
        //gameobject is a property of all MonoBehaviour classes
        //transform is a propert of all GameObjects
        pT = this.gameObject.transform;
        myRB = GetComponent<Rigidbody>();

        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ConditionalMoveExample();
        Vector3 dir = Direction();
        dir.y = 0;
        if(dir != Vector3.zero)
        {
            myRB.linearVelocity = dir * speed * Time.fixedDeltaTime;
        }
    }

    //ref from: https://discussions.unity.com/t/can-someone-help-me-make-a-simple-jump-script/145307/2
    void OnCollisionStay()
    {
    		isGrounded = true;
    }
    
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
    	    myRB.AddForce(jump * jumpForce);
    	    isGrounded = false;
        }
    }

    //simple directional calculation
    Vector3 Direction()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        return new Vector3(h,0,v);
    }


}
