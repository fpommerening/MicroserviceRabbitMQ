using System;
using System.Linq;
using FP.MsRMQ.PicFlow.ExternalApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.MsRMQ.PicFlow.ExternalApp.Binder
{
    public class ApiUploadBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration,
            params string[] blackList)
        {
            var upload = (instance as ApiUpload) ?? new ApiUpload();

            upload.Image = context.Request.Files.First();
            upload.ApiKey = context.Request.Form.ApiKey;
            upload.Message = context.Request.Form.Message;
            upload.User = context.Request.Form.User;

            return upload;
        }

        public bool CanBind(Type modelType)
        {
            return modelType == typeof(ApiUpload);
        }
    }
}
