using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BVL.Models
{
	public class Repository
	{
		public static List<Avrech> avrechimList
		{
			get
			{
				try
				{
					using (var db = new DatabaseEntities3())
					{
						return db.Avrech.ToList();

					}
				}
				catch
				{
					return new List<Avrech>();
				}


			}
		}

		public static List<HebroDetails> HebroDetailsList
		{
			get
			{
				using (DatabaseEntities3 db = new DatabaseEntities3())
				{
					return db.HebroDetails.ToList();

				}

			}
		}

		public static List<EnglishDetails> EnglishDetailsList
		{
			get
			{
				using (DatabaseEntities3 db = new DatabaseEntities3())
				{
					return db.EnglishDetails.ToList();

				}

			}
		}

		public static List<Subjects> SubjectsList
		{
			get
			{
				try
				{
					using (var db = new DatabaseEntities3())
					{
						return db.Subjects.ToList();

					}
				}
				catch
				{
					return new List<Subjects>();
				}

			}
		}

		public static List<Movie> MovieList
		{
			get
			{
				try
				{
					using (DatabaseEntities3 db = new DatabaseEntities3())
					{
						return db.Movie.ToList();

					}
				}
				catch
				{
					return new List<Movie>();
				}

			}
		}
		public static List<Books> BooksList
		{
			get
			{
				try
				{
					using (DatabaseEntities3 db = new DatabaseEntities3())
					{
						return db.Books.ToList();

					}
				}
				catch
				{
					return new List<Books>();
				}
			}
		}
		public static List<Audio> AudioList
		{
			get
			{
				try
				{
					using (DatabaseEntities3 db = new DatabaseEntities3())
					{
						return db.Audio.ToList();

					}
				}
				catch
				{
					return new List<Audio>();
				}

			}
		}

	}
}