using CommonLibrary.DBModels;
using CommonLibrary.Models;
using DataBaseAccessLibrary.FamousQuoteQuizDB.Models;
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
        public static UIResult<Page<GetUserModel>> GetUserList(UITableSortingAndFilterModel sortingAndFilterModel)
        {
            try
            {
                using(DataBaseContext db = new DataBaseContext())
                {
                    Page<GetUserModel> pagedata = new Page<GetUserModel>();
                    var dbuserlist = db.User.Where(u => !u.IsDeleted);
                    pagedata.TotalRows = dbuserlist.Count();
                    pagedata.List = dbuserlist.Skip(sortingAndFilterModel.PageSize * sortingAndFilterModel.PageIndex)
                                      .Take(sortingAndFilterModel.PageSize)
                                      .Select(u => new GetUserModel() 
                                      {
                                          Id = u.Id,
                                          Login = u.Login,
                                          CreationTime = u.CreationTime,
                                          Name = u.Name,
                                          SurName = u.SurName
                                      }).ToList();


                    return new UIResult<Page<GetUserModel>>(UIResultStatus.Success, pagedata);
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager GetUserList EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<Page<GetUserModel>>(UIResultStatus.Error, Errors.GetUserList_Error);
            }
           
        }
    }
}
