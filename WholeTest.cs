using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

//TODO Метод GeneratePack - генерирует набор Question в разброс --проверить
//TODO private ParseXML -- проверить
//TODO Создать аналогичный класс Journal и читать/записывать данные журнала в XML
/*
 * Хранение данных осуществляется в Metadata.xml
 * Сами задания хранятся картинками в папке Data/Img ниже exe-шника
 * Название картинки с заданием соответсвует его коду в metadata.xml
 * Организация metadata:
 * <questions>--┰---<SOLO>--┰---<вопрос 1>┰---Код
 *              |           |             ┕---Ответы(array) <------------- Пока не реализован массив
 *              |          ...
 *              |           ┕---<вопрос n>┰---Код
 *              |                         ┕---Ответы
 *              |
 *              ┣---<MULTI>--┰---<вопрос 1>┰---Код
 *              |            |             ┕---Ответы
 *              |           ...
 *              |            ┕---<вопрос n>┰---Код
 *              |                          ┕---Ответы
 *              |
 *              ┕--<OPENED>--┰---<вопрос 1>┰---Код
 *                           |             ┕---Ответы
 *                          ...
 *                           ┕---<вопрос n>┰---Код
 *                                         ┕---Ответы
 *                                     
 *Картинка: допустим, код = 101, тогда картинка = "Data/Img/101.png"
 *Журнал можно организовать подобным планом
 */
namespace ReadXML
{
	class WholeTest
	{
		private List<Question> pack;
		
		public static List<Question> ParseXML()
		{
			List<Question> rawList = new List<Question>();
            XmlDocument xmlData = new XmlDocument();
            xmlData.Load("Data/Metadata.xml");
            XmlElement root = xmlData.DocumentElement;
            if (root != null)
            {
                foreach (XmlElement node in root)
                {
                    // получаем атрибут name
                    XmlNode nodeAttribute = node.Attributes.GetNamedItem("name");
                    string strType = nodeAttribute?.Value;

                    Codes.Type type; //Convert string to Type
                    switch (strType)
                    {
                        case "SOLO": type = Codes.Type.SOLO; break;
                        case "MULTI": type = Codes.Type.MULTI; break;
                        case "OPENED": type = Codes.Type.OPENED; break;
                        default: type = Codes.Type.UNDEFINED; break;
                    }

                    foreach (XmlElement q in node.ChildNodes)
                    {
                        string img = "";
                        uint code = 0;
                        Dictionary<string, bool> answer = new Dictionary<string, bool>();
                        try
                        {

                            string attr = q.Attributes.GetNamedItem("code").Value ?? "0";
                            img = attr;
                            code = uint.Parse(attr);
                            foreach (XmlElement a in q.ChildNodes)
							{
                                if (a.Name == "a")
								{
                                    string t = a.Attributes.GetNamedItem("t").Value ?? "False";
                                    bool bt = ((t == Boolean.TrueString)
                                            || (t == Boolean.FalseString))
                                            ? Boolean.Parse(t) : false;
                                    
                                    answer.Add(a.InnerText, bt);
								}
							}
                        }
						catch
						{
							continue;
						}
						Question tmp = new Question(code, img, answer, type);
                        rawList.Add(tmp);
                    }
                }
            }
            return rawList;
		}

		public static List<Question> GeneratePack()
		{
            List<Question> fullList = new List<Question>();
            List<Question> generatedList = new List<Question>();
            fullList = ParseXML();

            byte[] counter = { 0, 0, 0, 0 };
            byte[] stopCondition = { 0, 10, 5, 5 };
            Random rnd = new Random();
            while (!counter.Equals(stopCondition))
            {
                int index = rnd.Next(fullList.Count);
                if (counter[(int)fullList[index].Type] <
                    stopCondition[(int)fullList[index].Type])
                {
                    generatedList.Add(fullList[index]);
                    counter[(int)fullList[index].Type]++;
                    fullList.RemoveAt(index);
                }
			}
            return generatedList;
		}
	}
}
