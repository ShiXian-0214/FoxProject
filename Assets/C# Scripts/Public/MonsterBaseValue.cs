using Unity.VisualScripting;
using UnityEngine;

public abstract class MonsterBaseValue : MonoBehaviour,IHpSystem
{
    [Header("BaseValue")]
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [Header("BaseElement")]
    [SerializeField] protected Rigidbody2D rigidbody2D = null;

    [SerializeField] private IAnimaControl animaControl;

    [Header("CoordinateValue")]
    [SerializeField] protected Transform leftPoint = null;
    [SerializeField] protected Transform rightPoint = null;
    [SerializeField] protected float leftX;
    [SerializeField] protected float rightX;
    [Header("FaceDirection")]
    [SerializeField] protected bool face = true;

    protected void init()
    {
        animaControl = this.GetComponent<IAnimaControl>();
        leftX = leftPoint.transform.position.x;
        rightX = rightPoint.transform.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }
    protected abstract void Move();
    public abstract void Dead();
    public abstract void Hurt(bool State);
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            collision2D.gameObject.GetComponent<HpSystem>()?.Attack(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player") 
        {
            animaControl.Attack(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player") 
        {
            animaControl.Attack(false);
        }
    }



}
