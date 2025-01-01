using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ResxUsage
{
    class Resx
    {
        public static string value1;
        public static string value2;

        public static class MemberInfoGetting
        {
            public static string GetMemberName<T>(Expression<Func<T>> expressionFunc)
            {
                MemberExpression memberExpression = (MemberExpression)expressionFunc.Body;

                return memberExpression.Member.Name;
            }
        }

        public static void Read()
        {
            CultureInfo cultureInfo = new CultureInfo("tr-TR");
            //Assembly assembly = Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name);
            ResourceManager resourceManager = new ResourceManager(typeof(Resource));

            if (resourceManager != null)
            {
                value1 = resourceManager.GetString(MemberInfoGetting.GetMemberName(() => value1), cultureInfo);
                value2 = resourceManager.GetString(MemberInfoGetting.GetMemberName(() => value2), cultureInfo);
            }
        }
    }
}
