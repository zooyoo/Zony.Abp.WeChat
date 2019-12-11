using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Zony.Abp.WeChat.Pay.Services.Pay;

namespace Zony.Abp.WeChat.Pay.Tests.Services
{
    public class PayService_Tests : AbpWeChatPayTestBase
    {
        private readonly OrdinaryMerchantPayService _ordinaryMerchantPayService;

        public PayService_Tests()
        {
            _ordinaryMerchantPayService = GetRequiredService<OrdinaryMerchantPayService>();
        }

        [Fact]
        public async Task UnifiedOrder_Test()
        {
            var result = await _ordinaryMerchantPayService.UnifiedOrderAsync("wxe32e0204e9db0b1c",
                "1540561391",
                "测试支付",
                DateTime.Now.ToString("yyyyMMddHHmmss"),
                101,
                TradeType.JsApi);
            
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task OrderRefund_Test()
        {
            var response = await _ordinaryMerchantPayService.RefundAsync("wxe32e0204e9db0b1c",
                "1540561391",
                "151515151515",
                "161616161616",
                101,
                50);
            
            response.ShouldNotBeNull();
        }
    }
}