using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


//Структура файла xml

/*
 * <Journal>
 *		<data>
 *			<group></group>
 *			<name></name>
 *			<surname></surname>
 *			<score></score>
 *			<mark></mark>
 *			<date></date>
 *			<time></time>
 *		</data>
 * </Journal>
 */
namespace Testing_system
{
	class Journal
	{
		//Класс журнала, методы заполнения файла журнала и его чтения с выводом в таблицу
		private List<User> data;
		private User currentUser;
		private string path = $"Data/Journal.xml"; 

		public User CurrentUser
		{
			get { return currentUser; }
			set { currentUser = value; }
		}

		public List<User> Data
		{ get { return data; } }
		public List<User> ParseXML()
		{
			//Чтение данных из файла и заполнение таблицы журнала тестирования
			List<User> list = new List<User>();
			XmlDocument xmlData = new XmlDocument();
			xmlData.Load(path);
			XmlElement root = xmlData.DocumentElement;
			if (root != null)
			{
				foreach (XmlElement data in root)
				{
					try
					{
						string group = data.SelectSingleNode("group").InnerText;
						string name = data.SelectSingleNode("name").InnerText;
						string surname = data.SelectSingleNode("surname").InnerText;
						int score = 0;
						Int32.TryParse(data.SelectSingleNode("score").InnerText, out score);
						int mark = 0;				
						Int32.TryParse(data.SelectSingleNode("mark").InnerText, out mark);
						string date = data.SelectSingleNode("date").InnerText;
					
						string time = data.SelectSingleNode("time").InnerText;
						
						User tmp = new User(surname, name, group, date.Trim(), time);
						
						tmp.Score = score;
						list.Add(tmp);
						}
						catch
						{
							continue;
						}
				}
			}
			return list;
		}
		public void XmlAdd(User user)
		{
			//Добавление нового прохождения теста в файл
			try
			{
				XDocument doc;
				try
				{
					doc = XDocument.Load(path);
				}
				catch (Exception exc)
				{
					doc = new XDocument(new XElement("Journal"));
				}
				XElement journal = doc.Element("Journal");
				string elapsed = user.Elapsed.ToString().Trim();
				elapsed = elapsed.Substring(0, elapsed.LastIndexOf('.'));
				journal.Add(new XElement("data",
						   new XElement("group", user.Group),
						   new XElement("name", user.Name),
						   new XElement("surname", user.Surname),
						   new XElement("score", user.Score),
						   new XElement("mark", user.Mark),
						   new XElement("date", user.Start.ToString("dd.MM.yyyy HH:mm:ss")),
						   new XElement("time", elapsed)));
				doc.Save(path);
			}
			catch { }
		}
	}
}
