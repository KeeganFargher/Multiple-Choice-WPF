

namespace MultipleChoiceLibrary
{
    public class LectureController : UserController
    {
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">The user to add</param>
        public void AddNewUser(User user)
        {
            if (user is null) { return; }
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users.Add(user);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a user
        /// </summary>
        /// <param name="user">The user to remove</param>
        public void RemoveUser(User user)
        {
            if (user is null) { return; }
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users.Remove(user);
                multipleChoiceEntities.SaveChanges();
            }
        }

        /// <summary>
        /// Removes a user
        /// </summary>
        /// <param name="ID">The user to remove</param>
        public void RemoveUser(int ID)
        {
            using (MultipleChoiceEntities multipleChoiceEntities = new MultipleChoiceEntities())
            {
                multipleChoiceEntities.Users.Remove(multipleChoiceEntities.Users.Find(ID));
                multipleChoiceEntities.SaveChanges();
            }
        }
    }
}
