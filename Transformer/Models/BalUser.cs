using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Transformer.Models
{
    
    public class BalUser
    {
        TransformerEntities dbcontext;

        #region Properties
        public long PK_User_Id { get; set; }
      
      
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Year { get; set; }
        public bool? Is_Active { get; set; }
        #endregion

        #region Constructor
        public BalUser()
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public BalUser(int id)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db bal = dbcontext.User_db.FirstOrDefault(c => c.PK_User_Id == id);
                if (bal != null)
                {
                    Username = bal.Username;
                    Password = bal.Password;
                    Year = bal.Year;
                    Phone = bal.Phone;
                    Address = bal.Address;
                    Is_Active = bal.Is_Active;
                    Email = bal.Email;
                    Name = bal.Name;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Methods
        public long Insert(BalUser bal)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db dal = new User_db();
                dal.Username = bal.Username;
                dal.Password = bal.Password;
                dal.Phone = bal.Phone;
                dal.Address = bal.Address;
                dal.Is_Active = bal.Is_Active;
                dal.Name = bal.Name;
                dal.Email = bal.Email;
                dal.Year = bal.Year;
                dbcontext.User_db.Add(dal);
                dbcontext.SaveChanges();
                return dal.PK_User_Id;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(BalUser bal, int id)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db abc = dbcontext.User_db.FirstOrDefault(c => c.PK_User_Id == id);
                if (abc != null)
                {
                    abc.Username = bal.Username;
                    abc.Password = bal.Password;
                    abc.Phone = bal.Phone;
                    abc.Address = bal.Address;
                    abc.Is_Active = true;
                    abc.Name = bal.Name;


                    dbcontext.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void updatelogin(string bal, int id)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db abc = dbcontext.User_db.FirstOrDefault(c => c.PK_User_Id == id);
                if (abc != null)
                {
                    abc.Year = bal;
                    abc.Is_Active = true;
                    dbcontext.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db abc = dbcontext.User_db.FirstOrDefault(c => c.PK_User_Id == id);
                if (abc != null)
                {
                    abc.Is_Active = false;
                    dbcontext.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public long Login(string pass, string user)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db bal = dbcontext.User_db.FirstOrDefault(c => c.Username == user && c.Password == pass && c.Is_Active == true);
                if (bal != null)
                {
                    return bal.PK_User_Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public long check(string user)
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                User_db bal = dbcontext.User_db.FirstOrDefault(c => c.Username == user);
                if (bal != null)
                {
                    return bal.PK_User_Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<BalUser> List()
        {
            try
            {
                if (dbcontext == null)
                    dbcontext = new TransformerEntities();

                IQueryable<User_db> bal = dbcontext.User_db.Where(c => c.Name != "");
                return bal.Select(c => new BalUser()
                {
                    Username = c.Username,
                    Password = c.Password,
                    Name = c.Name,
                    Address = c.Address,
                    Phone = c.Phone,
                    PK_User_Id = c.PK_User_Id,
                    Is_Active = c.Is_Active,
                }).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}