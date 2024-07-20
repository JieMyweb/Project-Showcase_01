using Autofac;
using System.Reflection;

namespace pr_common
{
    public class AutoRegister:Autofac.Module
    {
        //重寫Autofac管道Load方法,在這裡註冊注入
        protected override void Load(ContainerBuilder builder)
        {
            //程式集注入業務服務
            var IAppServices = Assembly.Load("pr_service");
            var AppServices = Assembly.Load("pr_service");
            //根據名稱約定(服務層的接口和實現均以Service結尾),實現服務接口和服務實現的依賴
            builder.RegisterAssemblyTypes(IAppServices, AppServices)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
