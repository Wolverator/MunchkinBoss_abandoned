﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunchkinBoss
{
    class Player
    {
        private bool _male;
        private uint _id, _level, _mercenaryCounter, _backpackCapacity = 5;
        private string _nickname;
        private playerRace _race,  _extraRace;//добавить до нескольких - полукровка, суперманчкин
        private playerClass _class, _extraClass;
        private int _power;
        private List<dynamic> _activeCurses, _backpack, _extraEquipment;//проклятья, рука, читы, наёмники, прочее дополнительное снаряжение
        private List<Treasure> _inventory;//карты в игре, на столе, неиспользуемые
        private Treasure _head, _body, _legs;
        private Treasure[] _hands;

        public Player(uint id, string nickname, bool male)
        {
            _id = id; _nickname = nickname; _male = male;
            _level = 1; _power = 0;
            _backpack = new List<dynamic>();
            _inventory = new List<Treasure>();
            _hands = new Treasure[2];
            _race = new playerRace("Человек");
            _class = null; _head = null; _body = null; _legs = null;
        }

        public void DrawDoor(uint count)
        {
            while (count > 0)
            {
                _backpack.Add(Game._doorDeck.Pop());
                count--;
            }
        }
        public void DrawTreasure(uint count)
        {
            while (count > 0)
            {
                _backpack.Add(Game._treasureDeck.Pop());
                count--;
            }
        }
        public void DiscardBackpack()
        {
            if (_backpack.Count > _backpackCapacity)
            {
                //выбрать, кому отдать карту, либо сбросить
                
            }

        }
        public void DiscardCard(dynamic card)
        {
            if (card.GetType() == Type.GetType("Treasure")) {
                int N = _backpack.IndexOf(card);
                Game._dicardPileTreasures.Add(_backpack.ElementAt(N));
                _backpack.Remove(card);
            }
            if (card.GetType() == Type.GetType("Door"))
            {
                int N = _backpack.IndexOf(card);
                Game._dicardPileDoors.Add(_backpack.ElementAt(N));
                _backpack.Remove(card);
            }
        }
    }
}