using CommonLibrary.DBModels;
using CommonLibrary.Models;
using DataBaseAccessLibrary.FamousQuoteQuizDB.Models;
using GatewayWebService.Helper;
using GatewayWebService.Model;
using LogLibrary;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService.Manager
{
    public class UserManager
    {
        public static UIResult<Page<GetUserListModel>> GetUserList(UITableSortingAndFilterModel sortingAndFilterModel)
        {
            try
            {
                using(DataBaseContext db = new DataBaseContext())
                {
                    Page<GetUserListModel> pagedata = new Page<GetUserListModel>();
                    var dbuserlist = db.User.Where(u => !u.IsDeleted);
                    pagedata.TotalRows = dbuserlist.Count();
                    pagedata.List = dbuserlist.Skip(sortingAndFilterModel.PageSize * sortingAndFilterModel.PageIndex)
                                      .Take(sortingAndFilterModel.PageSize)
                                      .Select(u => new GetUserListModel() 
                                      {
                                          Id = u.Id,
                                          Login = u.Login,
                                          CreationTime = u.CreationTime,
                                          Name = u.Name,
                                          SurName = u.SurName
                                      }).ToList();


                    return new UIResult<Page<GetUserListModel>>(UIResultStatus.Success, pagedata);
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager GetUserList EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<Page<GetUserListModel>>(UIResultStatus.Error, Errors.GetUserList_Error);
            }
           
        }
        public static UIResult<string> AddUser(AddUserModel model)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    User dbuser = new User()
                    {
                        Name = model.Name,
                        SurName = model.SurName,
                        Login = model.Login,
                        Password = HelperFunctions.Sha256(model.Password)
                    };

                    db.User.Add(dbuser);

                    return new UIResult<string>(UIResultStatus.Success,(string)null);
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager AddUser EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<string>(UIResultStatus.Error, Errors.To_Do);
            }

        }
        public static UIResult<string> EditUser(int userId, EditUserModel model)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    User dbuser = db.User.FirstOrDefault(u => !u.IsDeleted && u.Id == userId);

                    if(dbuser != null)
                    {
                        dbuser.Name = model.Name;
                        dbuser.SurName = model.SurName;
                        db.SaveChanges();
                        return new UIResult<string>(UIResultStatus.Success, (string)null);

                    }

                    return new UIResult<string>(UIResultStatus.Warning, Errors.To_Do);
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager AddUser EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<string>(UIResultStatus.Error, Errors.To_Do);
            }

        }
        public static UIResult<string> DeleteUser(int userId)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    User dbuser = db.User.FirstOrDefault(u => !u.IsDeleted && u.Id == userId);

                    if (dbuser != null)
                    {
                        dbuser.IsDeleted = true;
                        db.SaveChanges();
                        return new UIResult<string>(UIResultStatus.Success, (string)null);

                    }

                    return new UIResult<string>(UIResultStatus.Warning, Errors.To_Do);
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager AddUser EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<string>(UIResultStatus.Error, Errors.To_Do);
            }

        }
        public static UIResult<GetUserDetailsModel> GetUserDetails(int userId)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    User dbuser = db.User.Include(u => u.Quiz).FirstOrDefault(u => u.IsDeleted == false && u.Id == userId);
                    if(dbuser != null)
                    {
                        GetUserDetailsModel detialsmodel = new GetUserDetailsModel();
                        detialsmodel.Name = dbuser.Name;
                        detialsmodel.SurName = dbuser.SurName;
                        detialsmodel.Login = dbuser.Login;
                        detialsmodel.CreationTime = dbuser.CreationTime;
                        detialsmodel.QuizList = (List<GetQuizModel>)dbuser.Quiz.Where(q => !q.IsDeleted).Select(q => new GetQuizModel() { Text = q.Text, QuizTypeId = (QuizTypeEnum)q.QuizTypeId });

                        return new UIResult<GetUserDetailsModel>(UIResultStatus.Success, detialsmodel);

                    }

                    return new UIResult<GetUserDetailsModel>(UIResultStatus.Warning, Errors.To_Do);
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager GetUserList EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<GetUserDetailsModel>(UIResultStatus.Error, Errors.To_Do);
            }

        }


    }
}
