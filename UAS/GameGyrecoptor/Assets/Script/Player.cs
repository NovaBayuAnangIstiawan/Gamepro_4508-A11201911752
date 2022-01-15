using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public Characterdatabase characterDB;

    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public float attackSpeed = 0.5f;
	public float coolDown;
	public float bulletSpeed = 500;
    public float yValue = 1f; // perkiraan posisi muncul peluru pada y
    public float xValue = 0.2f; // perkiraan posisi muncul peluru pada x

	public float bulletPos; //posisi arah terbang peluru ada di kanan atau kiri
	public GameObject shootPos; //letak munculnya peluru terhadap gameobject

	public Rigidbody2D bulletPrefab; //objek peluru yg dimaksud


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletPos=1;
        
        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }

        else
        {
            Load();
        }

        UpdateCharacter(selectedOption); 
        
    }

        private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
        bool shoot = CrossPlatformInputManager.GetButtonDown("Jump"); //ambil nilai kontrol untuk tombol jump

		 if(Time.time >= coolDown) //cooldown tembakan
         {
             if(shoot) //jika button ditekan
             {
                 Fire();
             }
         }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
    void Fire(){
		//memunculkan peluru pada posisi gameobject shootpos
        Rigidbody2D bPrefab = Instantiate(bulletPrefab, shootPos.transform.position, shootPos.transform.rotation) as Rigidbody2D;
		//memberikan dorongan peluru sebesar bulletSpeed dengan arah terbangnya bulletPos 
		bPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed, 0));
		//counting cooldown, nanti dicek lagi
        coolDown = Time.time + attackSpeed;
     }
}