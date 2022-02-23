using CommonLibrary.Models;
using LogLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using HttpMethod = CommonLibrary.Models.HttpMethod;

namespace RequestLibrary
{
    public static class RequestManager
    {
        /// <summary>
        /// Used to make web requests to external resourses and returns string value
        /// </summary>
        /// <param name="method">Request Method (enum)</param>
        /// <param name="url">Request URL</param>
        /// <param name="body">Request Body (optional)</param>
        public static UIResult<string> Make(HttpMethod method, string url, object body = null, string basicAuthorizationToken = null, string[][] headers = null)
        {
            try
            {
                LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: Make :: Invoced with params => method: { method }, url: { url }, body: { JsonConvert.SerializeObject(body) }");
                HttpResponseMessage responseMessage = null;
                using (StringContent stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"))
                {
                    using HttpClient client = new HttpClient();
                    client.DefaultRequestVersion = HttpVersion.Version20;
                    if (basicAuthorizationToken != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthorizationToken);
                    }
                    if (headers != null)
                    {
                        foreach (string[] header in headers)
                        {
                            client.DefaultRequestHeaders.TryAddWithoutValidation(header[0], header[1]);
                        }
                    }
                    try
                    {
                        switch (method)
                        {
                            case HttpMethod.GET:
                                responseMessage = client.GetAsync(url).Result;
                                break;
                            case HttpMethod.POST:
                                responseMessage = client.PostAsync(url, stringContent).Result;
                                break;
                            case HttpMethod.PUT:
                                responseMessage = client.PutAsync(url, stringContent).Result;
                                break;
                            case HttpMethod.PATCH:
                                responseMessage = client.PatchAsync(url, stringContent).Result;
                                break;
                            case HttpMethod.DELETE:
                                responseMessage = client.DeleteAsync(url).Result;
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerClass.Log(LogLevel.ERROR, $"RequestLibrary :: RequestManager :: Make :: Invalid request: {ex}");
                        return new UIResult<string>(UIResultStatus.Warning, Errors.RequestLibrary_Request_Make_InvalidRequest);
                    }
                    LoggerClass.Log(LogLevel.TRACE, $"RequestLibrary :: RequestManager :: Make :: Response message: { JsonConvert.SerializeObject(responseMessage) }");
                }
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseString = responseMessage.Content.ReadAsStringAsync().Result;
                    LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: Make :: Successfully finished: { responseString }");
                    return new UIResult<string>(UIResultStatus.Success, responseString);
                }
                else
                {
                    LoggerClass.Log(LogLevel.WARN, "RequestLibrary :: RequestManager :: Make :: Not Success Status Code");
                    return new UIResult<string>(UIResultStatus.Warning, Errors.RequestLibrary_Request_Make_NotSuccessStatusCode);
                }
            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"RequestLibrary :: RequestManager :: Make :: UNHANDELED CASE: {ex}");
                return new UIResult<string>(UIResultStatus.Error, Errors.RequestLibrary_Request_Make_Exception);
            }
        }

        /// <summary>
        /// Used to make web requests to external resourses and returns generic object
        /// </summary>
        /// <param name="method">Request Method (enum)</param>
        /// <param name="url">Request URL</param>
        /// <param name="body">Request Body (optional)</param>
        public static UIResult<T> Make<T>(HttpMethod method, string url, object body = null, string basicAuthorizationToken = null, string[][] headers = null)
        {
            try
            {
                LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: Make<T> :: Invoced with params => method: { method }, url: { url }, body: { JsonConvert.SerializeObject(body) }");
                UIResult<string> result = Make(method, url, body, basicAuthorizationToken, headers);
                LoggerClass.Log(LogLevel.TRACE, $"RequestLibrary :: RequestManager :: Make<T> :: Response from [Make] function: { JsonConvert.SerializeObject(result) }");
                if (result.IsSuccessful())
                {
                    try
                    {
                        T responseObject = JsonConvert.DeserializeObject<T>(result.Data);
                        LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: Make<T> :: Successfully finished: { JsonConvert.SerializeObject(responseObject) }");
                        return new UIResult<T>(UIResultStatus.Success, responseObject);
                    }
                    catch (Exception)
                    {
                        LoggerClass.Log(LogLevel.WARN, "RequestLibrary :: RequestManager :: Make<T> :: Unable to parse json to class specified");
                        return new UIResult<T>(UIResultStatus.Warning, Errors.RequestLibrary_Request_Make_JsonToObjectParseFailure);
                    }
                }
                else
                {
                    LoggerClass.Log(LogLevel.WARN, "RequestLibrary :: RequestManager :: Make<T> :: Make function call failed");
                    return new UIResult<T>(result);
                }
            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"RequestLibrary :: RequestManager :: Make<T> :: UNHANDELED CASE {ex}");
                return new UIResult<T>(UIResultStatus.Error, Errors.RequestLibrary_Request_Make_Exception);
            }
        }


        /// <summary>
        /// Used to make web requests to internal resourses and returns generic object
        /// </summary>
        /// <param name="method">Request Method (enum)</param>
        /// <param name="url">Request URL</param>
        /// <param name="body">Request Body (optional)</param>
        /// <param name="headers">Request Body (optional)</param>

        public static UIResult<T> MakeInternal<T>(HttpMethod method, string url, object body = null, string[][] headers = null)
        {
            try
            {
                LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: MakeInternal<T> :: Invoced with params => method: { method.ToString() }, url: { url }, body: { JsonConvert.SerializeObject(body) }");
                UIResult<string> result = Make(method, url, body, null, headers);
                LoggerClass.Log(LogLevel.TRACE, $"RequestLibrary :: RequestManager :: MakeInternal<T> :: Response from [Make] function: { JsonConvert.SerializeObject(result) }");
                if (result.IsSuccessful())
                {
                    try
                    {
                        UIResult<T> responseObject = JsonConvert.DeserializeObject<UIResult<T>>(result.Data);
                        LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: MakeInternal<T> :: responseObject: {JsonConvert.SerializeObject(responseObject)}");
                        if (responseObject.IsSuccessful())
                        {
                            LoggerClass.Log(LogLevel.DEBUG, $"RequestLibrary :: RequestManager :: MakeInternal<T> :: Successfully finished: { JsonConvert.SerializeObject(responseObject) }");
                            return responseObject;
                        }
                        else
                        {
                            LoggerClass.Log(LogLevel.WARN, "RequestLibrary :: RequestManager :: MakeInternal<T> :: Make function call failed");
                            return new UIResult<T>(responseObject);
                        }
                    }
                    catch (Exception e)
                    {
                        LoggerClass.Log(LogLevel.WARN, "RequestLibrary :: RequestManager :: MakeInternal<T> :: Unable to parse json to class specified");
                        return new UIResult<T>(UIResultStatus.Warning, Errors.RequestLibrary_Request_Make_JsonToObjectParseFailure);
                    }
                }
                else
                {
                    LoggerClass.Log(LogLevel.WARN, "RequestLibrary :: RequestManager :: MakeInternal<T> :: Make function call failed");
                    return new UIResult<T>(result);
                }
            }
            catch (Exception ex)
            {
                LoggerClass.Log(LogLevel.ERROR, $"RequestLibrary :: RequestManager :: MakeInternal<T> :: UNHANDELED CASE: {ex}");
                return new UIResult<T>(UIResultStatus.Error, Errors.RequestLibrary_Request_Make_Exception);
            }
        }
    }
}
