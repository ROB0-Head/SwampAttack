using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealh;
    private Animator _animator;

    public event UnityAction<int,int> HealthChanged;
    public event UnityAction<int> MoneyChanged;
    
    public int Money { get; private set; }
    private void Start()
    {
        ChangedWeapon(_weapons[_currentWeaponNumber]);
        _currentHealh = _health;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }
    public void ApplyDamage(int damage)
    {
        _currentHealh -= damage;
        HealthChanged?.Invoke(_currentHealh,_health);
        if (_currentHealh <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void AddReward(int reward)
    {
        Money += reward;
        MoneyChanged?.Invoke(Money);
    }
    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;
        
        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;
        
        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangedWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
   
}