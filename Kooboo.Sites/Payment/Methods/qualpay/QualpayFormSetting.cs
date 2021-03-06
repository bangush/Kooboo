﻿using Kooboo.Data.Context;
using Kooboo.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kooboo.Sites.Payment.Methods.qualpay
{
    public class QualpayFormSetting : IPaymentSetting, ISettingDescription
    {
        public string Name => "QualpayFormPayment";

        public bool UseSandBox { get; set; }

        public string FailureUrl { get; set; }

        public string SuccessUrl { get; set; }

        public string MerchantId { get; set; }

        public string CheckoutProfileId { get; set; }

        public string SecurityKey { get; set; }

        public string WebHookKey { get; set; }

        public string ServerUrl
        {
            get
            {
                if (UseSandBox)
                {
                    return "https://app-test.qualpay.com";
                }
                return "https://api.qualpay.com";

            }
        }

        public string Group => "Payment";

        public string GetAlert(RenderContext renderContext)
        {
            return string.Empty;
        }
    }
}
