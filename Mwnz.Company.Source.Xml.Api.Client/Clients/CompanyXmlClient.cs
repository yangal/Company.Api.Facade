using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mwnz.Company.Source.Xml.Api.Clients
{
    public partial class Client
    {
        async partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response)
        {
            var status_ = ((int)response.StatusCode).ToString();
            if (status_ == "200")
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var xml = System.Xml.Linq.XElement.Parse(responseText);
                var json = JsonConvert.SerializeXNode(xml, Newtonsoft.Json.Formatting.None, true);
                response.Content = new StringContent(json);
            }

        }

    }
}
