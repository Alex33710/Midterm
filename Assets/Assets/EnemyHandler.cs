using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EnemyColor
{
    Red, Green, Blue
}
public class NewBehaviourScript : MonoBehaviour
{
    public bool isConnected;
    public GameObject RedEnemy, BlueEnemy, GreenEnemy;
    public EnemyColor enemyColor;
    public PlayerHandler playerHandler;
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 3);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyColor == EnemyColor.Red)
        {
            if (other.CompareTag("RedBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else if (enemyColor == EnemyColor.Green)
        {
            if (other.CompareTag("GreenBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else if (enemyColor == EnemyColor.Blue)
        {
            if (other.CompareTag("BlueBullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    void ColorChange()
    {
        switch (enemyColor)
        {
            case EnemyColor.Red:
                RedEnemy.SetActive(true);
                GreenEnemy.SetActive(false);
                BlueEnemy.SetActive(false);
                break;

            case EnemyColor.Green:
                RedEnemy.SetActive(false);
                GreenEnemy.SetActive(true);
                BlueEnemy.SetActive(false);
                break;

            case EnemyColor.Blue:
                RedEnemy.SetActive(false);
                GreenEnemy.SetActive(false);
                BlueEnemy.SetActive(true);
                break;
            default:
                break;
        }
    }
    void EnemyMove()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}