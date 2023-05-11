using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed;
    [SerializeField] float playerYBoundry;
    Delay delay;
    PlayerHealth playerHealth;

    public static bool canDash = true;
    public static bool isDashing;
    [SerializeField] float horizontalMove;

    [SerializeField] float dashAmount = 20f;
    [SerializeField] float dashTime = 0.3f;
    [SerializeField] float dashCooldown = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();    
    }

    // Surekli olarak karakterimiz hareket edecegi icin veya ne zaman asagiya duserek olecegini bilemedigimiz icin bu iki metodu Update icerisinde calistiriyoruz.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
        }
        horizontalMove = Input.GetAxis("Horizontal");
        MovementAction();
        PlayerDestroyer();
    }

    // Karakterimizin hareket etmesini saglayan metod. Once saga veya sola gitme duruma bagli olarak horizontalMove degiskenine -1 veya +1 atiyoruz. Bunu kontrol etmek icin ise Input.GetAxis("Horizontal") ile sagliyoruz. Horizontal yazmamizin sebebi su Unity bizim icin kolaylik saglamis. A veya sol ok basma durumunda -1, D veya sag ok basma durumunda +1 degeri donduruyor. Bizde bu duruma gore rigidBody2D ye velecotiy hiz vererek hareket etmesini sagliyoruz. Daha sonrasinda ise karakterimiz hangi yone bakmasi gerekiyor ise o yone dogru Flipleme (dondurme) islemini gerceklestiriyoruz.
    void MovementAction()
    {
        if (isDashing) 
        {
            return;
        }
        if (LevelManager.canMove) //Level managerdeki canMove bool deðeri true olduðu sürece haraket edilmesini saðlar.
        {
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            SpriteFlip(horizontalMove);

        }
    }

    // Karakterimizin sahip oldugu spriteRenderer icerisinde karakterimizi otomatik dondurmemizi saglayan .flipX metodu bulunuyor. Karakterimizin sola dogru gidiyorsa .flipX cevirerek karakterin donmesini sagliyoruz. Eger saga gidiyorsa donmesini iptal ediyoruz. SpriteFlip metodu karakterin hareket ettigi yone dogru bakmasini saglayan metod.
    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    // Karakterimiz asagiya duserek olebilir. PlayerDestroyer metodunda bu olayi gerceklestiriyoruz.
    void PlayerDestroyer()
    {
        if(transform.position.y < playerYBoundry)
        {
            SoundManager.instance.DeadByFallSound();
            Destroy(gameObject);
            Cancel();
            playerHealth.Lives();
            if (delay.delayTime == true)
            {
                delay.StartDelayTime();
            }                        
        }
    }
    private IEnumerator Dash()
    {
        Debug.Log("Dashing");
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        Jump.fallGravityScale = 0f;
        rb.velocity = new Vector2(horizontalMove * dashAmount, 0f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1f;
        Jump.fallGravityScale = 10f;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log("You can dash again");
        canDash = true;
    }
    public static void Cancel()
    {
        canDash = true;
        isDashing= false;
        Jump.fallGravityScale = 10f;
    }
}
