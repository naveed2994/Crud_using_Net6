using Application.Common.Abstract;
using Newtonsoft.Json;
using System.Text;

namespace UI.Helpers
{
    public class Helper : IHelper
    {
        public string ToString(string sEcho)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("{");
            sb.Append("\"sEcho\": ");
            sb.Append(sEcho);
            sb.Append(",");
            sb.Append("\"iTotalRecords\": ");
            sb.Append("");
            sb.Append(",");
            sb.Append("\"iTotalDisplayRecords\": ");
            sb.Append("");
            sb.Append(",");
            sb.Append("\"aaData\": ");
            sb.Append(JsonConvert.SerializeObject(""));
            sb.Append("}");
            return sb.ToString();
        }

    }
    public class SearchModel
    {
        public string value { get; set; }
    }
}
