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
 * <questions>--+---<SOLO>--+---<вопрос 1>+---Код
 *              |           |             +---Ответы(array) <------------- Пока не реализован массив
 *              |          ...
 *              |           +---<вопрос n>+---Код
 *              |                         +---Ответы
 *              |
 *              +---<MULTI>--+---<вопрос 1>+---Код
 *              |            |             +---Ответы
 *              |           ...
 *              |            +---<вопрос n>+---Код
 *              |                          +---Ответы
 *              |
 *              +--<OPENED>--+---<вопрос 1>+---Код
 *                           |             +---Ответы
 *                          ...
 *                           +---<вопрос n>+---Код
 *                                         +---Ответы
 *                                     
 *Картинка: допустим, код = 101, тогда картинка = "Data/Img/101.png"
 *Журнал можно организовать подобным планом
 */
namespace Testing_system
{
	class WholeTest
	{
		private List<Question> pack;
		
		public List<Question> ParseXML()
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
                        string img = q["code"].InnerText;
                        uint code = uint.Parse(img);
                        string answer = q["answer"].InnerText;
                        //TODO Читать ответы в List<string> из xml

                        //------------Костыль----------------------
                        List<string> _answer = new List<string>();
                        _answer.Add(answer);
                        //После исправления в конструктор должен передаваться answer
                        //-----------------------------------------
                        Question tmp = new Question(code, img, _answer, type);
                        rawList.Add(tmp);
                    }
                }
            }
            return rawList;
		}

		public void GeneratePack()
		{
            List<Question> fullList = new List<Question>();
            List<Question> generatedList = new List<Question>();
            fullList = ParseXML();

            byte[] counter = { 0, 0, 0, 0 };
            byte[] stopCondition = { 0, 10, 5, 5 };
            Random rnd = new Random();
            while (!counter.Equals(stopCondition))
            {
                int index = rnd.Next(fullList.Count - 1);
                if (counter[(int)fullList[index].Type] <
                    stopCondition[(int)fullList[index].Type])
                {
                    generatedList.Add(fullList[index]);
                    counter[(int)fullList[index].Type]++;
                    fullList.RemoveAt(index);
                }
			}
            pack = generatedList;
		}
	}
}
