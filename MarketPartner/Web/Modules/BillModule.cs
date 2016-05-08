using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using FP.MsRmq.ProcessChain.Contracts.Common;
using FP.MsRmq.ProcessChain.Contracts.Invoic;
using FP.MsRmq.ProcessChain.MarketPartner.Models;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Bill = FP.MsRmq.ProcessChain.MarketPartner.Models.Bill;

namespace FP.MsRmq.ProcessChain.MarketPartner.Modules
{
    public class BillModule : NancyModule
    {
        public BillModule()
        {
            Get["/bill"] = x =>
            {
                var modell = new Bill
                {
                    Number = string.Format("R-{0}", DateTime.Now.Ticks),
                    DocumentDate = DateTime.UtcNow.Date
                };
                return View["bill", modell];
            };

            Post["/bill", true] = async (x, ct) =>
            {
                Bill model = this.Bind<Bill>();
                var json = MapModelToJson(model);

                using (var handler = new HttpClientHandler{Credentials = new NetworkCredential(model.UserName, model.Password)})
                {
                    using (HttpClient client = new HttpClient(handler))
                    {
                        var content = new StringContent(json);
                        var result = await client.PostAsync("http://processServer:9090/service/", content);

                        Confirm confirm = new Confirm {Successful = true};
                        if (!result.IsSuccessStatusCode)
                        {
                            confirm.Successful = false;
                            confirm.ErrorText = string.Format("{0} - {1}", result.StatusCode, result.ReasonPhrase);
                        }
                        return View["confirm", confirm];
                    }
                }
            };

        }

        private static string MapModelToJson(Bill model)
        {
            var bill = new MsRmq.ProcessChain.Contracts.Invoic.Bill
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Number = model.Number,
                DocumentDate = model.DocumentDate,
                CustomerNumber = model.CustomerNumber,
                Address = new Address
                {
                    City = model.AddressCity,
                    Country = model.AddressCountry,
                    Number = model.AddressNumber,
                    Street = model.AddressStreet,
                    ZipCode = model.AddressZipCode
                }
            };
            var pos = new Position
            {
                Article = model.PosArticle,
                Comment = model.PosComment,
                Number = model.PosNumber,
                GrossAmmount = model.PosGrossAmmount,
                NetAmount = model.PosNetAmount,
                TaxAmmount = model.PosTaxAmmount,
                ValidFrom = model.PosValidFrom,
                ValidTo = model.PosValidTo
            };
            bill.Positions = new Collection<Position> {pos};

            return JsonConvert.SerializeObject(bill, Formatting.Indented);
        }
    }
}
