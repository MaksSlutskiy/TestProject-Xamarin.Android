﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Services
{
    public interface IKittenGenesisService
    {
        Kitten CreateNewKitten(string extra = "");
    }
}
