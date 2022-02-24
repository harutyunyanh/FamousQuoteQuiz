using CommonLibrary.DBModels;
using CommonLibrary.Models;
using DataBaseAccessLibrary.FamousQuoteQuizDB.Models;
using GatewayWebService.Helper;
using GatewayWebService.Model;
using LogLibrary;
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
    }
}
