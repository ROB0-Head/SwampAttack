using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _heath;
    [SerializeField] private int _reward;

    [SerializeField] private Player _target;
    
    public event UnityAction<Enemy> Dying;
    public int Reward => _reward;
    public Player Target => _target;
    
    public void Init(Player target)
    {
        _target = target;
    }
    
    public void TakeDamage(int damage)
    {
        _heath -= damage;
        if (_heath <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
    

}
