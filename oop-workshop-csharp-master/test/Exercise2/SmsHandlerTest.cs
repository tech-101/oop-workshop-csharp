using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise2.Support;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace oopworkshopcsharpmaster.test.Exercise2
{
  [TestClass]
    public class SmsHandlerTest
    {
        public SmsHandlerTest()
        {
        }

        public static readonly String DEVICE_ID = "myDeviceId";

    private SmsHandler smsHandler = new SmsHandlerImpl();

        [TestMethod]
    public void testBalanceCommand()
        {
            String response = smsHandler.handleSmsRequest("BALANCE", DEVICE_ID);
            Assert.AreEqual("1500", response);
        }

        [TestMethod]
    public void testSendOk()
        {
            String response = smsHandler.handleSmsRequest("SEND-100-FFRITZ", DEVICE_ID);
            Assert.AreEqual("OK", response);
        }

        [TestMethod]
    public void testSendInsufficientFunds()
        {
            String response = smsHandler.handleSmsRequest("SEND-100-FFRITZ", DEVICE_ID);
            Assert.AreEqual("ERR – INSUFFICIENT FUNDS", response);
        }

        [TestMethod]
    public void testSendNoUser()
        {
            String response = smsHandler.handleSmsRequest("SEND-100-FFRITZ", DEVICE_ID);
            Assert.AreEqual("ERR – NO USER", response);
        }

        [TestMethod]
    public void testTotalSent()
        {
            String response = smsHandler.handleSmsRequest("TOTAL-SENT-FFRITZ", DEVICE_ID);
            Assert.AreEqual("ERR – NO USER", response);
        }
    }
}
