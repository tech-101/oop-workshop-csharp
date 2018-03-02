using System;
using System.Collections.Generic; 
namespace oopworkshopcsharpmaster.NetlightTech101OOP.Exercise2.Support
{
    public interface TransferManager
    {
        void sendMoney(String senderUsername, String recipientUsername, Decimal amount);

        List<Decimal> getAllTransactions(String senderUsername, String recipientUsername);
    }
}
