using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

using (ApplicationContext db = new ApplicationContext())
{
    // Добавить пользователей, если их нет в Db
    /*User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 26 };
    db.Add(tom);
    db.Add<User>(alice);
    db.SaveChanges();*/



    IQueryable<User> query = db.Users;
    query = query.Where(item => item.Age > 27);
    query = query.Where(item => item.Age < 34);
    List<User> users = query.ToList();
    ;
}