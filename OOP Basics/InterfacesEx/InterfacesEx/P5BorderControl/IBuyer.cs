using System;
using System.Collections.Generic;
using System.Text;

public interface IBuyer
{
    int Food { get; }

    string Name { get; }

    void BuyFood();
}

