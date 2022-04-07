using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


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

		//TODO Чтение Journal.xml с заполнением списка User
		public List<User> ParseXML()
		{
			List<User> list = new List<User>();
			XmlDocument xmlData = new XmlDocument();
			xmlData.Load(path);
			XmlElement root = xmlData.DocumentElement;
			if (root != null)
			{
				foreach (XmlElement data in root)
				{
					//foreach (XmlElement a in data.ChildNodes)
					//{
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
					//}
				}
			}
			return list;
		}
		//TODO исправить отсутствие корня
		public void XmlAdd(User user)
		{
			XDocument doc = XDocument.Load(path);
			XElement journal = doc.Element("Journal");
			string elapsed = currentUser.Elapsed.ToString().Trim();
			elapsed=  elapsed.Substring(0, elapsed.LastIndexOf('.'));

			journal.Add(new XElement("data",
					   new XElement("group", CurrentUser.Group),
					   new XElement("name", CurrentUser.Name),
					   new XElement("surname", CurrentUser.Surname),
					   new XElement("score", CurrentUser.Score),
					   new XElement("mark", CurrentUser.Mark),
					   new XElement("date", CurrentUser.Start.ToString("dd.MM.yyyy HH:mm:ss")),
					   new XElement("time", elapsed)));
			doc.Save(path);
		}
	}
}
