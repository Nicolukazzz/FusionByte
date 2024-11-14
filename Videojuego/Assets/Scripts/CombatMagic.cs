using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMagic : MonoBehaviour
{

    [SerializeField] private GameObject magicAttackPrefab;
    [SerializeField] private Transform magicAttackSpawnPoint;

    private Animator animator;
    private Player_Health playerHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<Player_Health>();
    }

    private void Update()
    {
        if (playerHealth.getRecibiendoDano() == false)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                animator.SetTrigger("Magia");
                LaunchMagicAttack();
            }
        }
    }
    // Start is called before the first frame update
    public void LaunchMagicAttack()
    {
        // Determinar la dirección en la que el personaje está mirando
        int direction = transform.localScale.x > 0 ? 1 : -1;

        // Instanciar el proyectil y pasarle la dirección
        GameObject magicAttack = Instantiate(magicAttackPrefab, magicAttackSpawnPoint.position, Quaternion.identity);
        magicAttack.GetComponent<MagicAttack>().SetDirection(direction);
    }
}
