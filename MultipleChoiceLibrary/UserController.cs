
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleChoiceLibrary
{
    public class UserController
    {
        //  Add GetID...

        /// <summary>
        /// Retrieves the user's first name
        /// </summary>
        /// <param name="ID">The ID of the row the user is in</param>
        /// <returns>The first name of the user</returns>
        public static string GetFirstName(int ID) => GetUser(ID).Name;

        /// <summary>
        /// Sets the user's first name
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="value">The value to assign to the name</param>
        public static void SetFirstName(int ID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users
                    .FirstOrDefault(x => x.User_ID == ID)
                    .Name = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the user's surname
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <returns>The user's surname as a string</returns>
        public static string GetSurname(int ID) => GetUser(ID).Surname;

        /// <summary>
        /// Sets the user's surname
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="value">The value to assign to the surname</param>
        public static void SetSurname(int ID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users
                    .FirstOrDefault(x => x.User_ID == ID)
                    .Surname = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the user's password
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <returns>The user's password</returns>
        public static string GetPassword(int ID) => GetUser(ID).Password;

        /// <summary>
        /// Sets the user's password
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="value">The value to assign to the password</param>
        public static void SetPassword(int ID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users.FirstOrDefault(x => x.User_ID == ID)
                    .Password = value;
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the user's type eg. Student or Lecture
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <returns>Student or Lecture</returns>
        public static string GetType(int ID) => GetUser(ID).Type;

        /// <summary>
        /// Sets the user type eg. Student or Lecture
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="value">The value to assign to the type</param>
        public static void SetType(int ID, string value)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users.FirstOrDefault(x => x.User_ID == ID)
                    .Type = value;
                multipleChoiceEntities.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if the credentials match
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="password">The user's password</param>
        /// <returns>True if the ID and password match</returns>
        public static bool CredentialsMatch(int ID, string password)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                return multipleChoiceEntities.Users
                    .Any(e => e.User_ID == ID &&
                    e.Password == password);
            }
        }

        /// <summary>
        /// Checks if the credentials match async
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="password">The user's password</param>
        /// <returns>True if the ID and password match</returns>
        public static async Task<bool> CredentialsMatchAsync(int ID, string password)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                User user = await multipleChoiceEntities
                    .Users
                    .Where(x => x.User_ID == ID && x.Password == password)
                    .FirstOrDefaultAsync();

                return user != null;
            }
        }

        /// <summary>
        /// Retrieves the user with the specified ID.
        /// NB - Altered data will NOT be saved.
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>A user</returns>
        public static User GetUser(int userID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                User user = multipleChoiceEntities.Users
                    .FirstOrDefault(x => x.User_ID == userID);
                return user;
            }
        }
    }
}
