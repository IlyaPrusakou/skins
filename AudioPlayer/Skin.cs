﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    abstract class Skin
    {
        public Skin()
        {

        }
        public abstract void Clear();
        public abstract void Render(string str);
    }
}
