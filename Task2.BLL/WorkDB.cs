using System;
using System.Collections.Generic;
using System.Xml;

namespace Task2.BLL
{

    public class WorkDB
    {
        List<Currency> currencies = new List<Currency>();
        public List<Currency> ReadXml()
        {
            string path = "https://www.nationalbank.kz/rss/rates_all.xml";
            XmlDocument Xdoc = new XmlDocument();
            Xdoc.Load(path);
            XmlNodeList clist = Xdoc.GetElementsByTagName("title");
            XmlNodeList desc = Xdoc.GetElementsByTagName("description");
            XmlNodeList quant = Xdoc.GetElementsByTagName("quant");
            string example = "Official exchange rates of National Bank of Republic Kazakhstan";
            for (int i = 0; i < clist.Count; i++)
            {
                Currency cur = new Currency();
                if (desc[i].InnerText.ToString() != example)
                {
                    cur.title = clist[i].InnerText.ToString();
                    cur.description = Convert.ToDouble(desc[i].InnerText.Replace(".", ","));
                    cur.quant = Convert.ToInt32(quant[i - 1].InnerText);
                    currencies.Add(cur);
                }
            }
            return currencies;
        }
        public static string ConvertValue(List<Currency> currencies, string input_txt, string BoxInput, string BoxOut, bool check)
        {
            double input = Convert.ToDouble(input_txt);
            double value, desc;
            foreach (var item in currencies)
            {
                if (BoxOut == item.title || BoxInput == item.title)
                {
                    desc = item.description;
                    if (check) value = (input / desc) * item.quant;
                    else value = (input * desc) / item.quant;
                    return Math.Round(value, 3).ToString();
                }
            }
            return null;
        }
    }
}
