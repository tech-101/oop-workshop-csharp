using System;
using System.Numerics;

namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise2.Support
{
    public interface UserManager
    {
        Boolean existsUser(String username);

        Decimal getBalance(String username);

    }
}
