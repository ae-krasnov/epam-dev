using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Reflection;
using Microsoft.Practices.Unity;
using System.Configuration;
using Entities;
using DataAccess;
using Services;

namespace WebFormClient
{
    public class SimpleInjectorPageHandlerFactory : PageHandlerFactory
    {
        static IUnityContainer container;
        enum EntityType
        {
            author,
            book
        }
        enum DALType
        {
            file,
            memory,
            adonet,
            myorm
        }
        static EntityType CurrentEntity;
        static DALType CurrentDal;
        private static object GetInstance(Type type)
        {
            container = new UnityContainer();
            container.RegisterType(typeof(IServices<>), typeof(Service<>));
            CurrentEntity = (EntityType)Enum.Parse(typeof(EntityType), ConfigurationManager.AppSettings["EntityType"]);
            CurrentDal = (DALType)Enum.Parse(typeof(DALType), ConfigurationManager.AppSettings["AccessorType"]);
            switch (CurrentEntity)
            {
                case EntityType.author:
                    registerAuthorDAL();
                    return container.Resolve<IServices<Author>>();
                case EntityType.book:
                    registerBookDAL();
                    return container.Resolve<IServices<Book>>();
                default:
                    return null;
                    
            }
        }

        public override IHttpHandler GetHandler(HttpContext context,
            string requestType, string virtualPath, string path)
        {
            var handler = base.GetHandler(context, requestType,
                virtualPath, path);

            if (handler != null)
            {
                InitializeInstance(handler);
                HookChildControlInitialization(handler);
            }

            return handler;
        }

        private void HookChildControlInitialization(object handler)
        {
            Page page = handler as Page;

            if (page != null)
            {
                // Child controls are not created at this point.
                // They will be when PreInit fires.
                page.PreInit += (s, e) =>
                {
                    InitializeChildControls(page);
                };
            }
        }

        private static void InitializeChildControls(Control contrl)
        {
            var childControls = GetChildControls(contrl);

            foreach (var childControl in childControls)
            {
                InitializeInstance(childControl);
                InitializeChildControls(childControl);
            }
        }

        private static Control[] GetChildControls(Control ctrl)
        {
            var flags =
                BindingFlags.Instance | BindingFlags.NonPublic;

            return (
                from field in ctrl.GetType().GetFields(flags)
                let type = field.FieldType
                where typeof(UserControl).IsAssignableFrom(type)
                let userControl = field.GetValue(ctrl) as Control
                where userControl != null
                select userControl).ToArray();
        }

        private static void InitializeInstance(object instance)
        {
            Type pageType = instance.GetType().BaseType;

            var ctor = GetInjectableConstructor(pageType);

            if (ctor != null)
            {
                try
                {
                    var args = GetMethodArguments(ctor);

                    ctor.Invoke(instance, args);
                }
                catch (Exception ex)
                {
                    var msg = string.Format("The type {0} " +
                        "could not be initialized. {1}", pageType,
                        ex.Message);

                    throw new InvalidOperationException(msg, ex);
                }
            }
        }

        private static ConstructorInfo GetInjectableConstructor(Type type)
        {
            var overloadedPublicConstructors = (
                from ctor in type.GetConstructors()
                where ctor.GetParameters().Length > 0
                select ctor).ToArray();

            if (overloadedPublicConstructors.Length == 0)
            {
                return null;
            }

            if (overloadedPublicConstructors.Length == 1)
            {
                return overloadedPublicConstructors[0];
            }

            return null;
        }

        private static object[] GetMethodArguments(MethodBase method)
        {
            return (
                from parameter in method.GetParameters()
                let parameterType = parameter.ParameterType
                select GetInstance(parameterType)).ToArray();
        }

        private static void registerAuthorDAL()
        {
            switch (CurrentDal)
            {
                case DALType.file:
                    container.RegisterType(typeof(IAccessor<>), typeof(AuthorFileAccessor));
                    break;
                case DALType.memory:
                    container.RegisterType(typeof(IAccessor<>), typeof(AuthorMemoryAccess));
                    break;
                case DALType.adonet:
                    container.RegisterType(typeof(IAccessor<>), typeof(AuthorAdoNetAccessor));
                    break;
                case DALType.myorm:
                    container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Author>));
                    break;
                default:
                    break;
            }
        }

        private static void registerBookDAL()
        {
            switch (CurrentDal)
            {
                case DALType.file:
                    container.RegisterType(typeof(IAccessor<>), typeof(BookFileAccessor));
                    break;
                case DALType.memory:
                    container.RegisterType(typeof(IAccessor<>), typeof(BookMemoryAccessor));
                    break;
                case DALType.adonet:
                    container.RegisterType(typeof(IAccessor<>), typeof(BookAdoNetAccessor));
                    break;
                case DALType.myorm:
                    container.RegisterType(typeof(IAccessor<>), typeof(MyORM<Book>));
                    break;
            }
        }
    }
}