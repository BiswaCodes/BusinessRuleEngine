using PaymentBusinessRuleEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentBusinessRuleEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the payment type.");

            var paymentFor = Console.ReadLine();

            List<PostPaymentBaseRules> postPaymentRules = new List<PostPaymentBaseRules>();
            postPaymentRules.Add(new PackagingRules());
            postPaymentRules.Add(new CommissionRules());

            MembershipRules membershipRules = new MembershipRules();
            membershipRules.Add(() => membershipRules.ActivateMembership("Mbr1"));
            membershipRules.Add(() => membershipRules.UpgradeMembership("Premium"));

            //List<Func<bool>> funcs = new List<Func<bool>>();
            //funcs.Add(() => new PackagingRules().GenerateSlips("test1"));
            //funcs.Add(() => new PackagingRules().GenerateSlips("test2"));

            //foreach (var item in funcs)
            //{
            //    item();
            //}
            postPaymentRules.Add(membershipRules);
            postPaymentRules.ForEach(rule => rule.ExecuteRule());
            Console.ReadLine();

        }
    }
}
