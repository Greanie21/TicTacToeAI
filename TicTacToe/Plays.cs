﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Plays
    {
        private string key;
        private string value;

        public string Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }

        public Plays(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
