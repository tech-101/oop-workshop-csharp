using System;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise2.Support;
using oopworkshopcsharpmaster.NetlightTech101OOP.Exercise2;
using Xunit;

namespace oop_workshop.Tests.Excercise2
{
    public class SmsHandlerTest
    {
        public SmsHandlerTest()
        {
        }

        public static readonly String DEVICE_ID = "myDeviceId";

        private SmsHandler smsHandler = new SmsHandlerImpl();

        [Fact]
        public void testBalanceCommand()
        {
            String response = smsHandler.handleSmsRequest("BALANCE", DEVICE_ID);
            Assert.Equal("1500", response);
        }

        [Fact]
        public void testSendOk()
        {
            String response = smsHandler.handleSmsRequest("SEND-100-FFRITZ", DEVICE_ID);
            Assert.Equal("OK", response);
        }

        [Fact]
        public void testSendInsufficientFunds()
        {
            String response = smsHandler.handleSmsRequest("SEND-100-FFRITZ", DEVICE_ID);
            Assert.Equal("ERR – INSUFFICIENT FUNDS", response);
        }

        [Fact]
        public void testSendNoUser()
        {
            String response = smsHandler.handleSmsRequest("SEND-100-FFRITZ", DEVICE_ID);
            Assert.Equal("ERR – NO USER", response);
        }

        [Fact]
        public void testTotalSent()
        {
            String response = smsHandler.handleSmsRequest("TOTAL-SENT-FFRITZ", DEVICE_ID);
            Assert.Equal("ERR – NO USER", response);
        }
    }
}
