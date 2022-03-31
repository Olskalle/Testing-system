using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Testing_system
{
	class Journal
	{
		private List<User> data;
		private User currentUser;
		private string path = "Data/Journal.xml"; 

		public User CurUser
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
			//xmlData.Load("Data/Metadata.xml");
			return list;
		}

		public void XmlAdd(User user)
		{
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
			XDocument doc = XDocument.Load(path);
			XElement school = doc.Element("Journal");
			school.Add(new XElement("data",
					   new XElement("group", CurUser.Group),
					   new XElement("name", CurUser.Name),
					   new XElement("surname", CurUser.Surname),
					   new XElement("score", CurUser.Score),
					   new XElement("mark", CurUser.Mark),
					   new XElement("date", CurUser.Start.ToString("dd:mm:yyyy")),
					   new XElement("time", CurUser.Elapsed)));
			doc.Save(path);
		}
	}
}
