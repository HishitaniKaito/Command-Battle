using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public int _p_hp = 100;
    public int _e_hp = 500;
    public int _p_sp = 100;
    public int _p_limhp = 100;
    public int _e_limhp = 100;
    public int _p_limsp = 100;
    public int _skill = 0;
    int _item = 5;
    [SerializeField] Text _text;
    string _t;
    // Start is called before the first frame update
    void Start()
    {
        _p_hp = _p_limhp;
        _p_sp = _p_limsp;
        _e_hp = _e_limhp;
        _skill = 0;
        _item = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Kougeki()
    {
        _e_hp -= 50;
        _t = "攻撃して相手に50ダメージ";
        EnemyTurn();
    }
    public void Skill()
    {
        if(_p_sp > 20)
        {
            _skill = 3;
            _p_sp -= 20;
        }
        else
        {
            Debug.Log("sp切れてるから使えない");
        }
        EnemyTurn();
    }
    public void Item()
    {
        if(_item > 0)
        {
            _p_hp += 20;
            if (_p_hp > _p_limhp)
            {
                _p_hp = _p_limhp;
            }
            _item--;
        }
        else
        {
            Debug.Log("アイテムないよ");
        }
        EnemyTurn();
    }
    public void EnemyTurn()
    {
        if(_skill > 0)
        {
            int a = Random.Range(1, 5);
            if(a > 1)
            {
                _e_hp -= 50;
                Debug.Log("反射した");
                _skill--;
            }
        }
        else
        {
            _p_hp -= 50;
        }
        Debug.Log("敵のHP="+_e_hp+",自分のHP="+_p_hp);
        _t += "敵のHP=" + _e_hp + ",自分のHP=" + _p_hp;
        Debug.Log(_t);
    }
}
