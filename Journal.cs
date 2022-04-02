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
		private string path = "Data/Journal.xml"; 

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
					foreach (XmlElement a in data.ChildNodes)
					{
						try
						{
							string group = a.SelectSingleNode("group").InnerText;
							string name = a.SelectSingleNode("name").InnerText;
							string surname = a.SelectSingleNode("surname").InnerText;
							int score = 0;
							int.TryParse(a.SelectSingleNode("score").InnerText, out score);
							int mark = 0;
							int.TryParse(a.SelectSingleNode("mark").InnerText, out mark);
							string date = a.SelectSingleNode("date").InnerText;
							string time = a.SelectSingleNode("time").InnerText;
							User tmp = new User(surname, name, group, date, time);
							list.Add(tmp);
						}
						catch
						{
							continue;
						}
					}
				}
			}
			return list;
		}

		public void XmlAdd(User user)
		{
			XDocument doc = XDocument.Load(path);
			XElement journal = doc.Element("Journal");
			journal.Add(new XElement("data",
					   new XElement("group", CurrentUser.Group),
					   new XElement("name", CurrentUser.Name),
					   new XElement("surname", CurrentUser.Surname),
					   new XElement("score", CurrentUser.Score),
					   new XElement("mark", CurrentUser.Mark),
					   new XElement("date", CurrentUser.Start.ToString("dd.mm.yyyy HH:mm")),
					   new XElement("time", CurrentUser.Elapsed.ToString("hh:mm:ss"))));
			doc.Save(path);
		}
	}
}
