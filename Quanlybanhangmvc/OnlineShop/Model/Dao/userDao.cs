using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class userDao
    {
        onlineShop db = null;

        public userDao()
        {
            db = new onlineShop();
        }

        public int Insert(m_login login)
        {
            db.m_login.Add(login);
            db.SaveChanges();
            return login.Id;
        }


        public int InsertForFacebook(m_login login)
        {
            var user = db.m_login.SingleOrDefault(x => x.Name_user == login.Name_user);
            if (user == null)
            {
                db.m_login.Add(login);
                db.SaveChanges();
                return login.Id;
            }
            else
            {
                return user.Id;
            }

        }

        public m_login viewDetail(int id)
        {
            return db.m_login.Find(id);
        }

        public IEnumerable<m_login> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<m_login> model = db.m_login;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.Name_user.Contains(Search) || x.CreatedDate.ToString().Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public IEnumerable<m_login> listAllCreate(string Search, int page, int pageSize)
        {
            IQueryable<m_login> model = db.m_login;
            model = model.Where(x => x.Lastlogin >= DateTime.Now);

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.m_login.SingleOrDefault(x => x.Name_user == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status_user == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Pass == passWord)
                    {
                        //admin
                        if (result.Permission == 1)
                        {
                            return 1;
                        }
                        //nguoi mua
                        else if (result.Permission == 0)
                        {
                            return 0;
                        }
                        //nhan vien
                        else if (result.Permission == 2)
                        {
                            return 2;
                        }
                        else
                        {
                            return 3;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
            }
        }

        public m_login getById(string userName)
        {
            return db.m_login.SingleOrDefault(x => x.Name_user == userName);
        }

        public bool update(m_login ennity)
        {
            try
            {
                var user = db.m_login.Find(ennity.Id);
                user.Name_user = ennity.Name_user;

                if (!string.IsNullOrEmpty(ennity.Pass))
                {
                    user.Pass = ennity.Pass;
                }
                user.Permission = ennity.Permission;
                user.CreatedDate = ennity.CreatedDate;
                user.Status_user = ennity.Status_user;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updatePermission(m_login ennity)
        {
            try
            {
                var user = db.m_login.Find(ennity.Id);
                user.Permission = ennity.Permission;
                user.Status_user = ennity.Status_user;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.m_login.Find(id);
                db.m_login.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool changeStatus(int id)
        {
            var user = db.m_login.Find(id);

            user.Status_user = !user.Status_user;
            db.SaveChanges();
            return user.Status_user;
        }

        public bool chechUserName(string username)
        {
            return db.m_login.Count(x => x.Name_user == username) > 0;
        }

        public bool checkEmaik(string email)
        {
            return db.m_login.Count(x => x.Email == email) > 0;
        }
    }
}
