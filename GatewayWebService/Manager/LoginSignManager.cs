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
    public static class LoginSignManager
    {
        public static UIResult<LoginResponse> ClientLogin(LoginModel loginmodel)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    string pass = HelperFunctions.Sha256(loginmodel.Password);

                    Client client = db.Client.FirstOrDefault(c => c.Login == loginmodel.Login && c.Password == pass);

                    if(client!= null)
                    {

                        string Token = HelperFunctions.GenerateToken();


                        //ToDo Implement in DB/AWS/Azure
                        Tokens.clientTokenList.Add(Token, client.Id);

                        return new UIResult<LoginResponse>(UIResultStatus.Success, new LoginResponse() { Name = client.Name,SurName = client.SurName,Token = Token});
                    }
                    else
                    {
                        return new UIResult<LoginResponse>(UIResultStatus.Warning, Errors.Login_Faild);
                    }
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"LoginSignManager ClientLogin EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<LoginResponse>(UIResultStatus.Error, Errors.To_Do);
            }

        }

        public static UIResult<LoginResponse> UserLogin(LoginModel loginmodel)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    string pass = HelperFunctions.Sha256(loginmodel.Password);

                    User user = db.User.FirstOrDefault(c => c.Login == loginmodel.Login && c.Password == pass);

                    if (user != null)
                    {

                        string Token = HelperFunctions.GenerateToken();


                        //ToDo Implement in DB/AWS/Azure
                        Tokens.userTokenList.Add(Token, user.Id);

                        return new UIResult<LoginResponse>(UIResultStatus.Success, new LoginResponse() { Name = user.Name, SurName = user.SurName, Token = Token });
                    }
                    else
                    {
                        return new UIResult<LoginResponse>(UIResultStatus.Warning, Errors.Login_Faild);
                    }
                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"LoginSignManager UserLogin EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<LoginResponse>(UIResultStatus.Error, Errors.To_Do);
            }

        }


        public static UIResult<LoginResponse> ClientSign(SignModel signmodel)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    string pass = HelperFunctions.Sha256(signmodel.Password);

                    Client newclient = new Client()
                    {
                        Name = signmodel.Name,
                        Login = signmodel.Login,
                        SurName = signmodel.SurName,
                        Password = pass
                    };

                    db.Client.Add(newclient);
                    db.SaveChanges();
                    string Token = HelperFunctions.GenerateToken();


                    //ToDo Implement in DB/AWS/Azure
                    Tokens.clientTokenList.Add(Token, newclient.Id);


                    return new UIResult<LoginResponse>(UIResultStatus.Success, new LoginResponse() { Name = newclient.Name, SurName = newclient.SurName, Token = Token });

                };

            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"UserManager GetUserList EXCEPTION : {JsonConvert.SerializeObject(ex)}");
                return new UIResult<LoginResponse>(UIResultStatus.Error, Errors.To_Do);
            }

        }


    }
}
