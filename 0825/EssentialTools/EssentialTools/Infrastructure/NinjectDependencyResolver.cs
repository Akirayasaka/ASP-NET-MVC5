using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web.Common;
using EssentialTools.Models;
using System.Web.Mvc;

namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernekParam)
        {
            _kernel = kernekParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        // 透過AddBindings()來處理, 將實例化行為集中管理 
        private void AddBindings()
        {
            _kernel.Bind<IValueCalculator>().To<LinqValueCalculator>(); // 原始實作,沒有使用scope
            //_kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope(); // 一次只會實例化一個
            //_kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>(); // 原始實作 -> 對照Discount.cs
            //_kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("_DiscountSize", 50M); // 增加屬性 -> 對照Discount.cs
            _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M); // 使用建構式  -> 對照Discount.cs
            _kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>(); // 對照FlexibleDiscountHelper.cs
        }
    }
}